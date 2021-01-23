    {
      string line;
      int inside = 0;
      while ((line = sr.ReadLine()) != null)
      {
         if (line.StartsWith("some character"))
         {
             inside = !inside;
             // If you want to process the control line, do it here.
             continue;
         }
         if (inside)
         {
             // "line" is inside the block. The line starting with "some character"
             // is never here.
         }
         else
         {
             // Well, line is outside. And the control lines aren't here either.
         }
      }
    }
