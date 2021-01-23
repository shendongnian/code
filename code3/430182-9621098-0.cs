    public static bool IsConnectedToInternet
    {
        get
        {
            using (var ping = new Ping())
            {
                try
                {
                    var reply = ping.Send("173.194.41.168", 3000);
                    return reply.Status == IPStatus.Success;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
