    class Program
    {
        static void Main(string[] args)
        {
            new Messager(1000 * 2.5f);
            new Messager(1000 * 3);
    
            while (true)
            {
                Console.CursorTop = 0;
                Console.ReadLine();
            }
        }
    }
    
    public class Messager
    {
        Timer Timer;
    
        static int position = 1;
    
        public Messager(double interval)
        {
            this.Timer = new Timer(interval);
    
            this.Timer.Elapsed += (sender, e) =>
            {
                lock (this)
                {
                    var cursorLeft = Console.CursorLeft;
                    Console.CursorLeft = 0;
                    Console.CursorTop = position++;
                    Console.WriteLine("message from " + this.Timer.Interval);
                    Console.CursorTop = 0;
                    Console.CursorLeft = cursorLeft;
                }
            };
    
            this.Timer.Start();
        }
    }
