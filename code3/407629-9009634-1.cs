    foreach (Client c in Clients)
    {
        if (c.LoggedIn)
        {
            Trace.WriteLine("#TryWriteTo[" + c.Id + "](" + sm.Header + ")");
            Client client = c;
            LazyAsync.Invoke(() => client.WriteMessage(sm));
        }
    }
