    Dim str As String = "I ""love"" VB"
    Console.WriteLine(str)
    Console.WriteLine(str.Replace("""", ""))
    Catch ex As Exception
    Console.Write(ex.ToString())
    Finally
    Console.Read()
