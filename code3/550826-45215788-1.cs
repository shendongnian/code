    try
          {
               Tempaddr = System.Net.Dns.GetHostEntry("DESKTOP-xxxxxx");
          }
          catch (Exception ex) { }
          byte[] ab = new byte[6];
          int len = ab.Length, r = SendARP((int)Tempaddr.AddressList[1].Address, 0, ab, ref len);
            Console.WriteLine(BitConverter.ToString(ab, 0, 6));
