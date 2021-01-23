        public static void NetPing ()
        {            
            Ping pingSender = new Ping ();
            foreach (IPAddress address in YourNetwork)
            {
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
