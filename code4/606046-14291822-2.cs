    public class Program
    {
        private static Queue<Action> queue = new Queue<Action>();
        
        public static void Main(string[] args)
        {
            // put three things in the queue. 
            // In a simple world, they would finish in order.
            queue.Enqueue(() => DoWork(1));
            queue.Enqueue(() => DoComplicatedWork(2));
            queue.Enqueue(() => DoWork(3));
            
            PumpMessages();            
        }
        
        private static void PumpMessages()
        {
            while (queue.Count > 0)
            {
                Action action = queue.Dequeue();
                action();
            }
        }
        
        private static void DoWork(int i)
        {
            Console.WriteLine("Doing work: {0}", i);
        }
        
        private static void DoComplicatedWork(int i)
        {
            Console.WriteLine("Before doing complicated work: {0}", i);
            PumpMessages();
            Console.WriteLine("After doing complicated work: {0}", i);
        }
        
    }`
