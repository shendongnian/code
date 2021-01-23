    class ConsoleApplication
    {
    public static void Main()
    {
      Timer myTimer = new Timer();
      myTimer.Elapsed += new ElapsedEventHandler( DoAction );
      myTimer.Interval = 1000;
      myTimer.Start();
  
      while ( Console.Read() != 'q' )
      {
          ;    // do nothing...
      }
    }
    public static void DoAction( object source, ElapsedEventArgs e )
    {
        Console.WriteLine("Made request at {0}", DateTime.Now);
		
		using (WebClient client = new WebClient())
		{               
			using (Stream stream = client.OpenRead("http://whereever"))
			using (StreamReader reader = new StreamReader(stream))
			{
				Console.WriteLine(reader.ReadToEnd());
			}
		}
    }
    }
