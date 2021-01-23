      for (; ; )
      {
        Console.Write("?");
        if (PeekEscapeKey())
        {
          Console.WriteLine("esc");          
          continue;
        }
        Console.Write(">");
        var line = Console.ReadLine();
        Console.WriteLine(line);
      }
