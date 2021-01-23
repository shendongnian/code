    Delegate Sub _AddClient(ByVal client As Socket)
    Private Sub AddClient(ByVal client As Socket)
        If ListView1.InvokeRequired Then
            Invoke(New _AddClient(AddressOf AddClient), client)
            Exit Sub
        End If
        Dim lvi As New ListViewItem(client.LocalEndPoint.ToString)
        lvi.Tag = client
        ListView1.Items.Add(lvi)
    End Sub
