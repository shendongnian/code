        TcpClient tcpClient = (TcpClient)client;
        NetworkStream clientStream = tcpClient.GetStream();
        byte[] rcvBuffer = new byte[BUFSIZE]; // Receive buffer
        int bytesRcvd; // Received byte count
        while (ServiceRunning)  // Run forever, accepting and servicing connections
        {
            try
            {
                // Receive until client closes connection, indicated by 0 return value
                int totalBytesEchoed = 0;
                try
                {
                    while (((bytesRcvd = clientStream.Read(rcvBuffer, 0, rcvBuffer.Length)) > 0) && (ServiceRunning))
                    {
                        clientStream.Write(responseBytes, 0, responseBytes.Length);
                        WriteEventToWindowsLog("GSSResponderService", "Received "+System.Text.Encoding.UTF8.GetString(rcvBuffer), System.Diagnostics.EventLogEntryType.Information);
                        totalBytesEchoed += bytesRcvd;
                    }
                }
                catch(IOException)
                {
                    //HERE GOES CODE TO HANDLE CLIENT DISCONNECTION
                }
                catch(ObjectDisposedException)
                {
                    //HERE GOES CODE TO HANDLE CLIENT DISCONNECTION
                }
                WriteEventToWindowsLog("GSSResponderService", "Responded to " + totalBytesEchoed.ToString() + " bytes.", System.Diagnostics.EventLogEntryType.Information);
                // Close the stream and socket. We are done with this client!
                clientStream.Close();
                tcpClient.Close();
            }
            catch (Exception e)
            {
                WriteEventToWindowsLog("GSSResponderService", "Error:" + e.Message, System.Diagnostics.EventLogEntryType.Error);
                clientStream.Close();
                tcpClient.Close();
                break;
            }
        }
    }
