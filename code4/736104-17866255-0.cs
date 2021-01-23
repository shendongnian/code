    class Program
    {   
        string msg;
        static void Main(string[] args)
        {
            Program prog = new Program();
            Thread t1 = new Thread(prog.getInput);
            t1.Start();
            prog.otherThread();
        }
        public void otherThread()
        {
            while (true)
            {
                System.Threading.Thread.Sleep(3000);
                ClearCurrentConsoleLine();
                Console.WriteLine("Output");
            }
        }
        public void getInput()
        {
            while (true)
            {
                
                msg = Console.ReadLine();
            }
        }
        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write(" ");
            }
            Console.SetCursorPosition( 0, currentLineCursor + 1 );
            Console.Write(msg);
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
