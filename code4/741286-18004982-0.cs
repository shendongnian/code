        static void Main(string[] args)
        {
             for (int a = 10; a >= 0; a--)
             {
                 Console.SetCursorPosition(0,2);
                 Console.Write("Generating Preview in {0}", a);
                 System.Threading.Thread.Sleep(1000);
             }
        }
        static void Main(string[] args)
        {
             Console.Write("Generating Preview in {0}", a);
             for (int a = 10; a >= 0; a--)
             {
                 Console.CursorLeft = 22;
                 Console.Write(a.ToString());
                 System.Threading.Thread.Sleep(1000);
             }
        }
