        Public Class State
        Public CLient As Net.Sockets.Socket
        Public Const BufferConst As Integer = 100
        Public TmpBuffer(BufferConst) As Byte
        Public sb As New System.Text.StringBuilder
    End Class
    Public Sub SendText(txt As String, socket As Net.Sockets.Socket)
        socket.Send(System.Text.Encoding.UTF32.GetBytes(txt + "•"))
    End Sub
    Public Sub ReadData(ar As IAsyncResult)
        Dim state As State = ar.AsyncState
        Try
            Dim read As Integer = state.CLient.EndReceive(ar)
            If read > 0 Then
                state.sb.Append(System.Text.Encoding.UTF32.GetChars(state.TmpBuffer))
                If state.sb.ToString.IndexOf("•") > 0 Then
                    'All data have been recived
                    Console.WriteLine(state.sb.ToString())
                Else
                    ' Not Complete Start it again
                    state.CLient.BeginReceive(state.TmpBuffer, 0, state.BufferConst, Net.Sockets.SocketFlags.None, New AsyncCallback(AddressOf ReadData), state)
                End If
            End If
        Catch ex As Exception
            Console.Write("Read Error")
        End Try
    End Sub
