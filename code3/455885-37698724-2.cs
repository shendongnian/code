    public bool IsConnected(Socket socket)    
    {
        try
        {
            // this checks whether the cable is still connected 
            // and the partner pc is reachable
            Ping p = new Ping();
            if (p.Send(this.PartnerName).Status != IPStatus.Success)
            {
                // you could also raise an event here to inform the user
                Debug.WriteLine("Cable disconnected!");
                return false;
            }
            // if the program on the other side went down at this point
            // the client or server will know after the failed ping 
            if (!socket.Connected)
            {
                return false;
            }
            // this part would check whether the socket is readable it reliably
            // detected if the client or server on the other connection site went offline
            // I used this part before I tried the Ping, now it becomes obsolete
            // return !(socket.Poll(1, SelectMode.SelectRead) && socket.Available == 0);
        }
        catch (SocketException) { return false; }
    }
