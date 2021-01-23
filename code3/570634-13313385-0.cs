    if (ProxyBox.Text != string.Empty)
    {
        lock (locker)
        {
            Random rnd = new Random();
            int rndd = rnd.Next(0, proxysplit.Length);
            request.Proxy = new WebProxy(proxysplit[rndd].ToString());
        }
    }
