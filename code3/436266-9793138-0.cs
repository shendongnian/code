            DateTime DT = GetNISTDate(true);
            MessageBox.Show(DT.ToString());
        public static DateTime GetNISTDate(bool convertToLocalTime)
        {
            Random ran = new Random(DateTime.Now.Millisecond);
            DateTime date = DateTime.Today;
            string serverResponse = string.Empty;
            // Represents the list of NIST servers  
            string[] servers = new string[] {  
                         "64.90.182.55",  
                         "206.246.118.250",  
                         "207.200.81.113",  
                         "128.138.188.172",  
                         "64.113.32.5",  
                         "64.147.116.229",  
                         "64.125.78.85",  
                         "128.138.188.172" 
                          };
            // Try each server in random order to avoid blocked requests due to too frequent request
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    // Open a StreamReader to a random time server  
                    StreamReader reader = new StreamReader(new System.Net.Sockets.TcpClient(servers[ran.Next(0, servers.Length)], 13).GetStream());
                    serverResponse = reader.ReadToEnd();
                    reader.Close();
                    // Check to see that the signiture is there  
                    if (serverResponse.Length > 47 && serverResponse.Substring(38, 9).Equals("UTC(NIST)"))
                    {
                        // Parse the date  
                        int jd = int.Parse(serverResponse.Substring(1, 5));
                        int yr = int.Parse(serverResponse.Substring(7, 2));
                        int mo = int.Parse(serverResponse.Substring(10, 2));
                        int dy = int.Parse(serverResponse.Substring(13, 2));
                        int hr = int.Parse(serverResponse.Substring(16, 2));
                        int mm = int.Parse(serverResponse.Substring(19, 2));
                        int sc = int.Parse(serverResponse.Substring(22, 2));
                        if (jd > 51544)
                            yr += 2000;
                        else
                            yr += 1999;
                        date = new DateTime(yr, mo, dy, hr, mm, sc);
                        // Convert it to the current timezone if desired  
                        if (convertToLocalTime)
                            date = date.ToLocalTime();
                        // Exit the loop  
                        break;
                    }
                }
                catch
                {
                    /* Do Nothing...try the next server */
                }
            }
            return date;
        }
