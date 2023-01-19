Imports System
Imports System.ComponentModel.DataAnnotations
Imports System.Diagnostics.Metrics
Imports System.Globalization
Imports System.Numerics
Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates
Imports System.Threading

Module Program

    Public Class Planets

        Public Property PlanetName As String

        Public Property PlanetClassification As String

        Public Property PlanetSize As String

        Public Property DistanceFromSun As String

        Public Property PlanetPopulation As String

        Public Property PlanetFaction As List(Of String)






    End Class

    Public Class PlanetaryData

        Public Property SolSystemPlanets As New List(Of Planets) From {
        New Planets With {
        .PlanetName = "Mercury",
        .PlanetClassification = "Terrestrial",
        .PlanetSize = "4879",
        .DistanceFromSun = "57.9",
        .PlanetPopulation = "47500"
        },
        New Planets With {
        .PlanetName = "Venus",
        .PlanetClassification = "Terrestrial",
        .PlanetSize = "12104",
        .DistanceFromSun = "108.2",
        .PlanetPopulation = "304000"
        },
        New Planets With {
        .PlanetName = "Earth",
        .PlanetClassification = "Terrestrial",
        .PlanetSize = "12756",
        .DistanceFromSun = "149.6",
        .PlanetPopulation = "14000000000"
        },
        New Planets With {
        .PlanetName = "Mars",
        .PlanetClassification = "Terrestrial",
        .PlanetSize = "6792",
        .DistanceFromSun = "228.0",
        .PlanetPopulation = "1786000000"
        },
        New Planets With {
        .PlanetName = "Jupiter",
        .PlanetClassification = "Gas Giant",
        .PlanetSize = "142984",
        .DistanceFromSun = "778.5",
        .PlanetPopulation = "11500"
        },
        New Planets With {
        .PlanetName = "Saturn",
        .PlanetClassification = "Gas Giant",
        .PlanetSize = "120536",
        .DistanceFromSun = "1432.0",
        .PlanetPopulation = "0"
        },
        New Planets With {
        .PlanetName = "Uranus",
        .PlanetClassification = "Gas Giant",
        .PlanetSize = "51118",
        .DistanceFromSun = "2867.0",
        .PlanetPopulation = "0"
        },
        New Planets With {
        .PlanetName = "Neptune",
        .PlanetClassification = "Gas Giant",
        .PlanetSize = "49528",
        .DistanceFromSun = "4515.0",
        .PlanetPopulation = "0"
        }
        }

        Public Property DisplayData As New List(Of String) From {
        {"      Planets Name :"},
        {"    Classification :"},
        {"   Planet Diameter :"},
        {"  Orbital Distance :"},
        {"  Total Population :"}
        }

        Public Property DataSelector As New List(Of String) From {
            {".PlanetName"},
            {".PlanetClassification"},
            {".PlanetSize"},
            {".DistanceFromSun"},
            {".PlanetPopulation"}
        }


    End Class

    Public Class SolarSystem

        Private Property _StarName As String

        Private Property _StarClassification As String

        Private Property _Generation As String

        Private Property _SolarSystemPopulation As Long

        Private Property _PlanetList As List(Of String)

        Public Property StarName() As String
            Get
                Return _StarName
            End Get
            Set(ByVal value As String)
                _StarName = value
            End Set
        End Property

        Public Property StarClassification() As String
            Get
                Return _StarClassification
            End Get
            Set(ByVal value As String)
                _StarClassification = value
            End Set
        End Property

        Public Property Generation() As String
            Get
                Return _Generation
            End Get
            Set(ByVal value As String)
                _Generation = value
            End Set
        End Property

        Public Property SolarSystemPopulation() As Long
            Get
                Return _SolarSystemPopulation
            End Get
            Set(ByVal value As Long)
                _SolarSystemPopulation = value
            End Set
        End Property

        Public Property PlanetList() As List(Of String)
            Get
                Return _PlanetList
            End Get
            Set(ByVal value As List(Of String))
                _PlanetList = value
            End Set
        End Property


    End Class

    Public Class SolarSystemData



    End Class


    Public Class CharacterData


        Public Property CharacterInventory As New Dictionary(Of String, Integer) From {
        {"Fuel", 1000},
        {"Rations", 50},
        {"Research", 10},
        {"Weapons", 15},
        {"Credits", 500}
        }


    End Class
    Public Class UserInterface

        Dim PD As New PlanetaryData()
        Dim CD As New CharacterData()

        Dim PlanetSelection As Integer = 0
        Dim CharacterMenuSelection As Integer = 0

        Dim Planets As New List(Of String) From {"    |   Mercury   |", "    |   Venus     |", "    |   Earth     |", "    |   Mars      |", "    |   Jupiter   |", "    |   Saturn    |", "    |   Uranus    |", "    |   Neptune   |"}

        Dim MenuOptions As New List(Of String) From {"          INVENTORY", "          TRAVEL", "          BARTER", "          RETURN"}

        Dim CursorPosition As Integer = 0
        Public Sub Barter()

            Dim FuelCost As Integer = 2
            Dim PurchaseAmount As Integer
            Dim TransactionTotal As Integer = FuelCost * PurchaseAmount
            Dim UserInput As String


            Console.Clear()
            Console.WriteLine("Your Balances Are: ")
            Console.WriteLine($"Fuel: {CD.CharacterInventory("Fuel")}")
            Console.WriteLine($"Credits: {CD.CharacterInventory("Credits")}")
            Console.WriteLine()
            Console.WriteLine($"Fuel Cost is {FuelCost} credits")
            Console.WriteLine("How much fuel would you like to purchase? ")

            UserInput = Console.ReadLine()

            If Integer.TryParse(UserInput, 0) = True Then

                PurchaseAmount = UserInput
                Console.WriteLine($"Purchasing {PurchaseAmount} units of fuel")
                Console.WriteLine("Press any key to continue...")
                Console.ReadKey()
                Console.WriteLine($"Total Transaction amount is {FuelCost} x {PurchaseAmount} which equals {FuelCost * PurchaseAmount}")
                Console.WriteLine("Press any key to continue...")
                Console.ReadKey()
                CD.CharacterInventory("Fuel") = CD.CharacterInventory("Fuel") + PurchaseAmount
                CD.CharacterInventory("Credits") = CD.CharacterInventory("Credits") - (FuelCost * PurchaseAmount)
                Console.WriteLine("Your New Balances Are: ")
                Console.WriteLine($"Fuel: {CD.CharacterInventory("Fuel")}")
                Console.WriteLine($"Credits: {CD.CharacterInventory("Credits")}")
                Console.WriteLine("Press any key to continue...")

            Else

                Console.WriteLine("Andy please quit trying to break my program. My head hurts")
                Console.WriteLine("Press any key to continue...")
                Console.ReadLine()



            End If






        End Sub

        Public Sub DisplayCharacterInventory()

            For Each InventoryItem As KeyValuePair(Of String, Integer) In CD.CharacterInventory

                Console.WriteLine($"{InventoryItem.Key}: {InventoryItem.Value}")

                'Counter += 1

            Next

        End Sub
        Public Sub DisplayCharacterMenu()

            'CursorPosition = 0
            Console.Clear()

            Console.WriteLine()
            ListPlanets()
            Console.WriteLine()

            For Each value In MenuOptions

                If MenuOptions.IndexOf(value) = CursorPosition Then

                    Console.WriteLine($"{value}<<<")

                Else

                    Console.WriteLine(value)

                End If

            Next

            CharacterMenuNav()

            DisplayCharacterMenu()

        End Sub
        Public Sub CharacterMenuNav()

            Dim NavKey As ConsoleKeyInfo


            NavKey = Console.ReadKey()

            If NavKey.Key = 38 Then

                If CursorPosition > 0 Then

                    CursorPosition -= 1

                End If

            ElseIf NavKey.Key = 40 Then

                If CursorPosition <= (4) Then

                    CursorPosition += 1

                End If

            ElseIf NavKey.Key = 13 Then

                CharacterMenuSelection = CursorPosition
                CharacterMenuSelectionDisplay()
                Console.ReadKey()

            End If

        End Sub

        Public Sub CharacterMenuSelectionDisplay()

            Select Case (CharacterMenuSelection)

                Case 0

                    DisplayCharacterInventory()
                    Console.ReadKey()
                    DisplayCharacterMenu()

                Case 1

                    Console.WriteLine("ERROR ENGINES OFFLINE FOR REPAIRS. PRESS ANY KEY TO CONTINUE")
                    Console.ReadKey()
                    DisplayCharacterMenu()

                Case 2

                    Barter()
                    Console.ReadKey()
                    DisplayCharacterMenu()

                Case 3

                    Console.Clear()
                    ShorterPlanetList()

            End Select



        End Sub

        Public Sub DisplayPlanetsSelection()

            Console.WriteLine()
            Console.WriteLine($"{PD.DisplayData(0)} {PD.SolSystemPlanets(PlanetSelection).PlanetName}")
            Console.WriteLine($"{PD.DisplayData(1)} {PD.SolSystemPlanets(PlanetSelection).PlanetClassification}")
            Console.WriteLine($"{PD.DisplayData(2)} {PD.SolSystemPlanets(PlanetSelection).PlanetSize}")
            Console.WriteLine($"{PD.DisplayData(3)} {PD.SolSystemPlanets(PlanetSelection).DistanceFromSun}")
            Console.WriteLine($"{PD.DisplayData(4)} {PD.SolSystemPlanets(PlanetSelection).PlanetPopulation}")

        End Sub
        Public Sub ListPlanets()

            For Each value In Planets

                Console.WriteLine(value)

            Next


        End Sub
        Public Sub ShorterPlanetList()

            Console.WriteLine()

            For Each value In Planets

                If Planets.IndexOf(value) = CursorPosition Then

                    Console.WriteLine($"{value}<<<")

                Else

                    Console.WriteLine(value)

                End If

            Next

            Console.WriteLine()
            Console.WriteLine("PRESS ENTER TO SELECT A PLANET OR PRESS 'M' TO OPEN THE MENU")

            PlanetMenuNav()

            Console.Clear()
            ShorterPlanetList()

        End Sub
        Public Sub PlanetMenuNav()

            Dim NavKey As ConsoleKeyInfo


            NavKey = Console.ReadKey()

            If NavKey.Key = 38 Then

                If CursorPosition > 0 Then

                    CursorPosition -= 1

                End If

            ElseIf NavKey.Key = 40 Then

                If CursorPosition <= (6) Then

                    CursorPosition += 1

                End If

            ElseIf NavKey.Key = 13 Then

                PlanetSelection = CursorPosition
                DisplayPlanetsSelection()
                Console.ReadKey()

            ElseIf NavKey.Key = 77 Then

                CursorPosition = 0
                DisplayCharacterMenu()


            End If


        End Sub
        Public Sub DisplayCharacterSelection()



        End Sub
        Public Sub ListPlanetNames()

            Dim x As Integer = 0

            Dim SelectedPlanet As Integer = 0

            For Each value In PD.SolSystemPlanets

                Console.WriteLine(PD.SolSystemPlanets(x).PlanetName)

                x += 1

            Next

        End Sub


    End Class


    Sub Main()


        Dim UI As New UserInterface()

        UI.ShorterPlanetList()

        'UI.DisplayCharacterInventory()

        'UI.Test()


    End Sub
End Module

