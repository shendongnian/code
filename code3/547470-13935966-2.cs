      Bitmap original = new Bitmap("Test.jpg");
      long mem1 = Process.GetCurrentProcess().PrivateMemorySize64;
      Stopwatch timer = Stopwatch.StartNew();
      List<Bitmap> list = new List<Bitmap>();
      Random rnd = new Random();
      for(int i = 0; i < 50; i++)
      {
        list.Add(new Bitmap(original));
      }
      long mem2 = Process.GetCurrentProcess().PrivateMemorySize64;
      Debug.WriteLine("ElapsedMilliseconds: " + timer.ElapsedMilliseconds);
      Debug.WriteLine("PrivateMemorySize64: " + (mem2 - mem1));
