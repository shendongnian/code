           public static string Check(string keyword)
             {
            Ping pingSender = new Ping();
            //PingOptions options = new PingOptions();
            // Use the default Ttl value which is 128, 
            // but change the fragmentation behavior. 
           // options.DontFragment = true;
            // Create a buffer of 32 bytes of data to be transmitted. 
            //string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            // byte[] buffer = Encoding.ASCII.GetBytes(data);
            // int timeout = 120;
            try
            {
                PingReply reply = pingSender.Send(keyword);
                return "found";
            }
            catch
            {
                return "not found";
            }
        }
