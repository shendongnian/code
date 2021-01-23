    public bool checkNet()
    {
        bool kleir = false;
        using (Ping ping = new Ping())
        {
            try
            {
                if (ping.Send("yourDomain.com", 2000).Status == IPStatus.Success)
                {
                    kleir = true;
                }
            }
            catch (PingException)
            {
                kleir = false;
            }
        }
        return kleir;
    }
