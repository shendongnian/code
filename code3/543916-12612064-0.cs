    static void barreader_method()
    {
       barreader.OpenPort(barport, 19200); //opens the port connected to the rfid reader
       byte TagType; //tag type
       byte[] TagSerial = new byte[4]; //tag serial in reverse order
       byte ReturnCode = 0; //return code sent from the rfid reader
       string bartagno; //tag no as a string
       string previousbartango;
       var lastTimeCalled = DateTime.MinValue;
    
       while (true)
       {
          bartagno = "";
          while (!barreader.CMD_SelectTag(out TagType, out TagSerial, out ReturnCode)) /*wait until a tag is present in the rf field, if present return the tag number.*/
          {
          }
          for (int i = 0; i < 4; i++)
          {
             bartagno += TagSerial[i].ToString("X2");
          }
          var spanSinceLastCalled = DateTime.Now - lastTimeCalled;
          if (spanSinceLastCalled > TimeSpan.FromMinutes(1) || bartango != previousbartango)
          {
              barprocess(bartagno); //barprocess method
              previousbartango = bartango;
              lastTimeCalled = DateTime.Now;
          }
          Thread.Sleep(1200); //this is to prevent multiple reads
       }
    }
