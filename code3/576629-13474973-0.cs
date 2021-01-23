        //send rcon command and get response
        string response = "";
        try
        {
            this.server.Socket.Send(bufferSend, SocketFlags.None);
            do
            {
                int bytesReceived = this.server.Socket.Receive(bufferRec);
                response += Encoding.ASCII.GetString(bufferRec, 0, bytesReceived);
                System.Threading.Thread.Sleep(10);
            } while (this.server.Socket.Available > 0);
        }
        catch (SocketException e)
        {
            MessageBox.Show(e.ToString(), "Error occured");
        }
