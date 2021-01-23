    Dim name, s As String
    name = "John"
    Console.Write("Enter your Name (just hit <Enter> to keep ""{0}""): ", name)
    s = Console.ReadLine()
    If Trim(s) <> "" Then
        name = s
    End If
    Console.WriteLine("Result = {0}", name)
    Console.ReadKey()
