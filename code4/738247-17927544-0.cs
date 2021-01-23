      for (int i = 1; i <= 255; i++) {
        IPAddress addr = IPAddress.Parse("100.10.100."+i);
        try
        {
          entry = Dns.GetHostEntry(addr);
          //some other codes that cause exception
        }
        catch(SocketException ex)
        {
          //do something
        }
        catch(Exception ex)
        {
          //catch all other exceptions
        }
      }
