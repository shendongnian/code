    Public Class Sessions
    Public Shared Function GetValueOfSession(ByVal SessionName As String)
        If HttpContext.Current.Session(SessionName) Is Nothing Then
            Return Nothing
        Else
            Return HttpContext.Current.Session(SessionName).ToString
        End If
    End Function
    End Class
