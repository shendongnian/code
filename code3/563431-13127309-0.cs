    public class MyState //TODO give better name
    {
        public int State1 { get; set; }
        public int State2 { get; set; }
    }
    
    public class ABase
    {
        public MyState state = new MyState()
        {
            State1 = 1,
            State2 = 2
        };
    
        List<Action<MyState>> workers = new List<Action<MyState>>();
    
        public ABase()
        {
            CreateWorkers();
        }
    
        public void DoWork()
        {
            foreach (var action in workers)
            {
                action(state);
            }
        }
    
        private void CreateWorkers()
        {
            workers.Add(new Worker1().DoWork);
            workers.Add(Worker2.Process);
        }
    }
    
    public class Worker1
    {
        public void DoWork(MyState state)
        {
            Console.WriteLine(state.State1);
        }
    }
    
    public class Worker2
    {
        public static void Process(MyState state)
        {
            Console.WriteLine(state.State2);
        }
    }
