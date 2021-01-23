    Module Module1
    
        Sub Main()
            Dim n As New N()
    
            With n
                n.S = "This"
            End With
    
            Console.ReadKey()
        End Sub
    
    
        Class N
            Public Property S As String
                Get
    
                End Get
                Set(value As String)
                    Console.WriteLine("Setter") //written second
                End Set
            End Property
    
            Sub New()
                Console.WriteLine("Constructor") //written first
            End Sub
        End Class
    End Module
