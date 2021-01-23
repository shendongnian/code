    foreach (var proxy in File.ReadAllLines("proxy.txt"))
    {
        try
        {
            using (var wc = new WebClient())
            {
                wc.Proxy = new WebProxy(proxy);
                string page wc.DownloadString(textBox2.Text);
                return page;
            }
        }
        catch { }
    }
