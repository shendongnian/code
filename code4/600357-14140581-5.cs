       private static void Main(string[] args)
       {
        int flags;
        bool isConnected = false;
        try
        {
          isConnected = InternetGetConnectedState(out flags, 0);
        } catch (Exception err)
        {
          Console.WriteLine(err.Message);
        }
        Console.WriteLine(string.Format("Is connected :{0} Flags:{1}", isConnected, flags));
       }
      }
