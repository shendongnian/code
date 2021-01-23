    class Program
    {
        static void Main(string[] args)
        {
            new Messager(1000 * 2.5f);
            new Messager(1000 * 3);
            while (true)
            {
                Console.ReadLine();
            }
        }
    }
    public class Messager
    {
        Timer Timer;
        public Messager(double interval)
        {
            this.Timer = new Timer(interval);
            this.Timer.Elapsed += (sender, e) =>
            {
                int currentTopCursor = Console.CursorTop;
                int currentLeftCursor = Console.CursorLeft;
                Console.MoveBufferArea(0, currentTopCursor, Console.WindowWidth, 1, 0, currentTopCursor + 1);
                Console.CursorTop = currentTopCursor;
                Console.CursorLeft = 0;
                Console.WriteLine("message from " + this.Timer.Interval);
                Console.CursorTop = currentTopCursor +1;
                Console.CursorLeft = currentLeftCursor;
            };
            this.Timer.Start();
        }
    }
