    static void GetFunc2(Timer timer, int i)
    {
      for (; i < 5; ++i)
      {
        int i2 = i; // STORE IT
        timer.Elapsed += (obj, e) =>
          {
            Console.WriteLine(i2); // USE THE NEWLY STORED VERSION
          };
      }
    }
