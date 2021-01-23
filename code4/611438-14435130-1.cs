    Imports MyCSharpNamespace
    
    Public Class AnotherClass
        Public ReadOnly Property V As Single
            Get
                Return AClass(Of XX).m_var
            End Get
        End Property
    End Class
    Public Class XX
        Implements [INterface]
    End Class
