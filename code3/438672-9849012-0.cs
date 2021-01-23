    Public Sub SendData(ByVal Data() As Byte)
        Try
            Dim Length As Integer = Data.Length
            Dim D() As Byte = BitConverter.GetBytes(Data.Length)
            ReDim Preserve D(D.Length + Data.Length - 1)
            Data.CopyTo(D, 4)
            client.BeginSend(D, 0, D.Length, 0, AddressOf sockSendEnd, client)
        Catch
            RaiseEvent onError(Err.Description)
        End Try
    End Sub
