    Private Async Sub ProcessTcpClient(__TcpClient As Net.Sockets.TcpClient)
            If __TcpClient Is Nothing OrElse Not __TcpClient.Connected Then Return
            Dim __RequestBuffer(0) As Byte
            Dim __BytesRead As Integer
            Using __NetworkStream As Net.Sockets.NetworkStream = __TcpClient.GetStream
                __BytesRead = __TcpClient.Client.Receive(__RequestBuffer, 0, 1, SocketFlags.Peek)
                If __BytesRead = 1 AndAlso __RequestBuffer(0) = 22 Then
                    Await Me.ProcessTcpClientSsl(__NetworkStream)
                Else
                    Await Me.ProcessTcpClientNonSsl(__NetworkStream)
                End If
            End Using
            __TcpClient.Close()
    End Sub
