        private PingReply Ping(string ip, int tryCount = 0)
        {
            var ping = new Ping();
            byte[] buffer = new byte[65500];
            var pingReply = ping.Send(ip, 500, buffer, new PingOptions(600, false));
            if (pingReply.Status == IPStatus.Success)
            {
                return pingReply;
            }
            if (tryCount < 5)
            {
                Thread.Sleep(50);
                return Ping(ip, tryCount + 1);
            }
            return pingReply;
        }
