    Public Property ClosedDateDTP() As String
        Get
            If _closedDate = Nothing Then
                Return String.Empty
            Else
                Return _closedDate.ToString
            End If
        End Get
        Set(value As String)
            If value = Nothing Then
                _closedDate = Nothing
            Else
                _closedDate = CDate(value)
            End If
        End Set
    End Property
