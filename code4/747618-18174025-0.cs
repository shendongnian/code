      try {
        ...
      }
      catch (AppServerException e) {
        Console.WriteLine("Application server failed to get data with the message:");
        Console.WriteLine(e.Message); // <- What's actually got wrong with it
      }
