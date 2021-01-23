    Private Sub ChangeTab(ByVal tabName As String, Optional ByVal clearAll As Boolean)
    
        Yadyyada(tabName)
    
        If IsMissing(clearAll) = True Or clearAll = True Then
            DoMoreStuff
        End If
    
    End Sub
