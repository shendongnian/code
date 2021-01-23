     public static long IP2Long(string ip)
       {
           string[] ipBytes;
           double num = 0;
           if(!string.IsNullOrEmpty(ip))
           {
               ipBytes = ip.Split('.');
               for (int i = ipBytes.Length - 1; i >= 0; i--)
               {
                   num += ((int.Parse(ipBytes[i]) % 256) * Math.Pow(256, (3 - i)));
               }
           }
           return (long)num;
       }
