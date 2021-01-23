    private async Task SubmitMessage(string strMessage)
    {
        try
        {
            using (StreamSocket objSocket = new StreamSocket())
            {
                await objSocket.ConnectAsync(new HostName(TargetHostname), TargetPortservice);
                BindListener(objSocket.Information.LocalPort, objSocket, strMessage);
            }
        }
        catch (Exception objException)
        {
            Debug.WriteLine(objException.Message);
            throw;
        }
    }
