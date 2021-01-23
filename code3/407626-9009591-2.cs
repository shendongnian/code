    lock (ClientLocker)
    {
        Trace.WriteLine("#WriteAll: " + sm.Header);
        foreach (Client c in Clients)
        {
            if (c.LoggedIn)
            {
                Trace.WriteLine("#TryWriteTo[" + c.Id + "](" + sm.Header + ")");
                
                Client copyOfC = c;
                LazyAsync.Invoke(() => copyOfC.WriteMessage(sm));
            }
        }
    }
