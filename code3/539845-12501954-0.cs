    Public Class MyEnumObj
        Private _Value As String
        Public ReadOnly Property Value As String
            Get
                Return _Value
            End Get
        End Property
        Private Sub New()
            ' Hide the default constructor '
        End Sub
        Public Sub New(inValue As String)
            _Value = inValue
        End Sub
    End Class
