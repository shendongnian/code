    Imports System
    
    Public Class Test
        Public Shared Sub Main(args As String())
            Dim p As String = "Original"
            Foo(p)
            Console.WriteLine(p)
        End Sub
        
        Public Shared Sub Foo(ByRef p As Object)
            p = "Changed"
        End Sub
    End Class
