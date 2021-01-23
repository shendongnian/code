    public static class Draw
    {
        public static void Rectangle(int top, int left, int width, int height, ConsoleColor color)
        {
            if (width < 0)
                throw new ArgumentException("width must be greater or equal zero.", "width");
            if (height < 0)
                throw new ArgumentException("height must be greater or equal zero.", "height");
            var oldPositionLeft = Console.CursorLeft;
            var oldPositionTop = Console.CursorTop;
            var oldColor = Console.BackgroundColor;
            Console.BackgroundColor = color;
            for (int i = 0; i < height; i++)
            {
                Console.SetCursorPosition(left, top + i);
                Console.Write(new String(' ', width));
            }
            Console.SetCursorPosition(oldPositionLeft, oldPositionTop);
            Console.BackgroundColor = oldColor;
        }
