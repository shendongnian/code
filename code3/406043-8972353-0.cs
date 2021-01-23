    Public Shared Sub Thread_TcpListener_GUI()
    Dim tcpListener As TcpListener = Nothing
	Try
            'Client starts listening to server here
            tcpListener = New TcpListener(System.Net.IPAddress.Any, 4960)
            tcpListener.ExclusiveAddressUse = False
            Call tcpListener.Start()
    Catch ex As Exception
            MsgBox(ex.message)
    End Try
	
    While True
        Dim tcpClient As TcpClient = Nothing
        Dim tcpNetworkStream As NetworkStream = nothing
		
        Try
                If Listener.Pending() Then
				
					tcpClient = tcpListener.AcceptTcpClient
					tcpNetworkStream = tcpClient.GetStream()
					Dim strMessageReceived As String = ""
					'Get received message
					While tcpNetworkStream.DataAvailable
						Dim byteReceived(tcpClient.ReceiveBufferSize) As Byte
						tcpNetworkStream.Read(byteReceived, 0, CInt(tcpClient.ReceiveBufferSize))
						strMessageReceived &= Encoding.UTF8.GetString(byteReceived).Trim(Convert.ToChar(0))
					End While
					'Send response message
					If strMessageReceived <> "" Then
						Dim strResponse As String = "Received!"
						Dim byteResponse As Byte() = Encoding.UTF8.GetBytes(strResponse)
						tcpNetworkStream.Write(byteResponse, 0, byteResponse.Length)
					End If
					
					tcpClient.Close()
					tcpNetworkStream.close()
				End If
        Catch ex As Exception
            Call Console.WriteLine(ex.Message)
        Finally
            Thread.Sleep(1500)
        End Try
    End While
    End Sub
