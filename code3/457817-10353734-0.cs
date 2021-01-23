    if (!m_Clients.ContainsKey(packet.SerialNumber))
    {
        m_Clients.Add(packet.SerialNumber, client);
        
        AddLogText("Running UpdateClientList\r\n");
        UpdateClientList();
        AddLogText("Doing client.refreshAll\r\n");
        string[] packets = client.refreshAll();
        AddLogText("Doing for loop\r\n");
        for (int i = 0; i < packets.Length; i++)
        {
            byte[] byteData = Encoding.ASCII.GetBytes(packets[i]);
            client.SocketState.clientSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(SendCallback), client);
            AddPacketsSentText(packets[i] + "--" + (iSent++).ToString() + "\r\n\r\n");
        }
    }
