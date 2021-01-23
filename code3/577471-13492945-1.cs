        public static void NetPing()
        {            
            Ping pingSender = new Ping();
            foreach (string adr in stringAddressList)
            {
               IPAddress address = IPAddress.Parse(adr);
               PingReply reply = pingSender.Send (address);
               if (reply.Status == IPStatus.Success)
               {
                    //Computer is active
               }
               else
               {
                    //Computer is down
               }
            }  
        }
