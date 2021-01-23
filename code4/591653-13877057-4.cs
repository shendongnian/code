    MustInherit Class Base
        Public MustOverride ReadOnly Property someArray() As Integer()
    End Class
    Class Derived
        Inherits Base
        Public Overrides ReadOnly Property someArray() As Integer()
            Get
                Static _someArray As Int32() = New Integer() {1, 2, 3, 4}
                Return _someArray
            End Get
        End Property
    End Class
