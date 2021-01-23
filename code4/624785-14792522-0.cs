        class Program
        {
            static void Main(string[] args)
            {
                ConsoleText(19, 1, "Hello!");
                Console.Read();
            }
        }
        public static void ConsoleText(int x, int y, string Text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(x, y);
            Console.Write(string.Format("x:{0}, y:{1}, message:{2}", x, y, Text));
            Console.ResetColor();
        }
