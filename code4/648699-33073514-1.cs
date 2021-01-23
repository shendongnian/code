        while (true)
        {
          Console.Write(".");
          if (Console.CursorLeft + 1 >= Console.BufferWidth)
          {
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(Enumerable.Repeat<char>(' ', Console.BufferWidth).ToArray());
            Console.SetCursorPosition(0, Console.CursorTop - 1);
          }
          if (Console.KeyAvailable)
            break;
        }
      
