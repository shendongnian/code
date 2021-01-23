    public bool CheckInternetConnection(string HostName) 
    {
        bool result = false; // assume error
        try {
            Ping oPing = new Ping();
            PingReply reply = oPing.Send(HostName, 3000);
            if (reply.Status == IPStatus.Success){
                result = true;
            }
        } catch (Exception E) {
            // Uncomment next line to see errors
            // MessageBox.Show(E.ToString());
        }
        return result;
    }
