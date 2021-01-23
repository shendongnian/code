    Try
        If tcpListener IsNot Nothing Then
             tcpListener.Stop()
             tcpListener = Nothing
        End If
    Catch ex As Exception
    End Try
