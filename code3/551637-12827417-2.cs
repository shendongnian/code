    private void DoIt()
    {
        int i = 0;
        while (true)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<Chat>();
            hubContext.Clients.addMessage("Doing it... " + i);
            i++;
            Thread.Sleep(500);
        }
    }
