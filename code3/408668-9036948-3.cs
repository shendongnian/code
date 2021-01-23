    Delegate Function SearchMethod(ByVal inputString As String, patterns As IEnumerable(Of String)) As Boolean
    Private Function LikePattern(inputString As String, patterns As IEnumerable(Of String)) As Boolean
        Dim query = patterns.Where(Function(p) (Not p Is Nothing))
        If Not query.Any Then
            Throw New ArgumentException("LikePattern needs at least one pattern that is not null!", "patterns")
        End If
    
        For Each pattern In patterns
            If inputString Like pattern Then Return True
        Next
        Return False
    End Function
    
    
