    class InternetConnectionChecker
    {
        private bool _connectingFlag = false;
        private Thread _th;
        #region Ping Google To Test Connect Or Disconnect
        private string Ping()
        {
            try
            {
                const string remoteMachineNameOrIP = "173.194.78.104";
                var ping = new Ping();
                var reply = ping.Send(remoteMachineNameOrIP, 5);
                var sb = new StringBuilder();
                sb.Append(reply.Status.ToString());
                return sb.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion
      
        #region Connecting Cheker Thread
        private void ConCheck()
        {
            var status = Ping();
            _connectingFlag = status == "Success" || status == "TimedOut";
        }
        public bool ConnectingCheker()
        {
            _th = new Thread(ConCheck);
            _th.Start();
            return _connectingFlag;
        }
        #endregion
    }
