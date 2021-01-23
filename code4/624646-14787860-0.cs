    class ColoredText
    {
      public int x, y; // koordinaterna
      public string hello;
      ConsoleColor farg;  // removed the utf-8 char
        public ColoredText(int x, int y, string Position)
        {
           Console.ForegroundColor = farg;
           Console.SetCursorPostion(x,y);
           Console.Write(Position);
           Console.ResetColor();
        }
    }
