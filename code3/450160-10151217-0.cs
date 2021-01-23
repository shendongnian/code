    if (Strings.Add(s))
    {
        // string is new. process it.
        // and add it to the expiration queue
        Expirations.Enqueue(new Tuple<DateTime, String>(DateTime.Now + ExpireTime, s));
    }
