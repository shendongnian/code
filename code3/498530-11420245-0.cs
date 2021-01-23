    static void Go(object ineedthis)
    {
      string data = (string)ineedthis;
      lock (locker)
      {
        if (!done) { Console.WriteLine ("Done"); done = true; }
      }
    }
