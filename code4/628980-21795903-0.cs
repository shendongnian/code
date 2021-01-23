        private void myPingCompletedCallback(object sender, PingCompletedEventArgs e)
        {
            if (e.Cancelled)
                return;
            if (e.Error != null)
                return;
            if (e.Reply.Status == IPStatus.Success)
            {
                //ok connected to internet, do something
            }
        }
        private void checkInternet()
        {
            Ping myPing = new Ping();
            myPing.PingCompleted += new PingCompletedEventHandler(myPingCompletedCallback);
            byte[] buffer = new byte[32];
            int timeout = 1000;
            PingOptions options = new PingOptions(64, true);
            try
            {
                myPing.SendAsync("google.com", timeout, buffer, options);
            }
            catch
            {
            }
        }
