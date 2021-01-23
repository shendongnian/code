    var manager = new TerminalServicesManager();
    using (var server = manager.GetLocalServer())
    {
        server.Open();
        foreach (var session in server.GetSessions())
        {
            if (session.ConnectionState == ConnectionState.Active)
            {
                Console.WriteLine(session.ClientName);
            }
        }
    }
