    Public Event MyPropertyChanged(ByVal sender As Object, ByVal e As EventArgs)
 
    '...
    Public Property MyProperty() As String
        Get
            Return _myProperty
        End Get
        Set (ByVal value as String)
            _myProperty = value
            RaiseEvent(Me, New EventArgs())
        End Set
    End Property
