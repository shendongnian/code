      public bool netWorkAvailable()
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                Logger.log(TAG, "netWorkAvailable()");
                return true;
            }
            return false;
        }
     if (netWorkAvailable())
       {
         buffer.Append(SERVER_URL);
         buffer.Append("_req=").Append(8);
         httpConnection = new HttpConnection();
         httpConnection.connect(REQ_REGISTRATION, buffer.ToString(), listener, null);
         httpConnection.Post();
        }
