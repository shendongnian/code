    void Read()
    {
      object x = collection.Last;
      // The collection may get swapped out right here.
      object y = collection.Last;
      if (x != y)
      {
        Console.WriteLine("It could happen!");
      }
    }
