    Option Strict On
    
    Public Class Test
        Public Shared Sub Main(args As String())
          Dim x as System.Collections.Generic.ICollection(Of String) = args
          Console.WriteLine(x(0))
        End Sub
    End Class
