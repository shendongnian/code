    int oldVal = -1;
    
    while (true)
    {
      int newVal = GetNewValue();
      if (newVal != oldVal)
      {
         Console.WriteLine(newVal);
         oldVal = newVal ;
      }
      Thread.Sleep(1000 * 60 * 3)
    }
