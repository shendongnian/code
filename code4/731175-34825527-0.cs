    void utfchars()
    {
     int i, a, b, x;
     ConsoleKeyInfo z;
      do
      {
       a = 0; b = 0; Console.Clear();
        for (i = 1; i <= 10000; i++)
        {
         if (b == 20)
         {
          b = 0;
          a = a + 1;
         }
        Console.SetCursorPosition((a * 15) + 1, b + 1);
        Console.Write("{0} == {1}", i, (char)i);
       b = b+1;
       if (i % 100 == 0)
      {
     Console.Write("\n\t\t\tPress any key to continue {0}", b);
     a = 0; b = 0;
     Console.ReadKey(true); Console.Clear();
     }
    }
    Console.Write("\n\n\n\n\n\n\n\t\t\tPress any key to Repeat and E to exit");
    z = Console.ReadKey();
    if (z.KeyChar == 'e' || z.KeyChar == 'E') Environment.Exit(0);
    } while (1 == 1);
    }
