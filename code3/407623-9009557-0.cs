    lock (ClientLocker)
    {
        Trace.WriteLine("#WriteAll: " + sm.Header);
        foreach (Client c in Clients)
        {
            if (c.LoggedIn)
            {
                Client localC = c;
                Trace.WriteLine("#TryWriteTo[" + c.Id + "](" + sm.Header + ")");
                LazyAsync.Invoke(() => localC.WriteMessage(sm));
            }
        }
    }
