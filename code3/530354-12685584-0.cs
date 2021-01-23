    public delegate void ProcessFinished(IParallelProcess process);
    public interface IParallelProcess
    {
        void Start();
        event ProcessFinished ProcessFinished;
    }
    public class ParallelProcessBasket : ConcurrentQueue<IParallelProcess>
    {
        public void Put(IParallelProcess process)
        {
            base.Enqueue(process);
        }
        public IParallelProcess Get()
        {
            IParallelProcess process = null;
            base.TryDequeue(out process);
            return process;
        }
    }
    public class ParallelProcessor<T> where T : class
    {
        private ParallelProcessBasket basket;
        private readonly int MAX_DEGREE_OF_PARALLELISM;
        private Action<T> action;
        public ParallelProcessor(int degreeOfParallelism, IEnumerable<IParallelProcess> processes, Action<T> action)
        {
            basket = new ParallelProcessBasket();
            this.action = action;
            processes.ToList().ForEach(
                (p) =>
                {
                    basket.Enqueue(p);
                    p.ProcessFinished += new ProcessFinished(p_ProcessFinished);
                });
            MAX_DEGREE_OF_PARALLELISM = degreeOfParallelism;
        }
        private void p_ProcessFinished(IParallelProcess process)
        {
            if (!basket.IsEmpty)
            {
                T element = basket.Get() as T;
                if (element != null)
                {
                    Task.Factory.StartNew(() => action(element));
                }
            }
        }
        public void StartProcessing()
        {
            // take first level of iteration
            for (int cnt = 0; cnt < MAX_DEGREE_OF_PARALLELISM; cnt++)
            {
                if (!basket.IsEmpty)
                {
                    T element = basket.Get() as T;
                    if (element != null)
                    {
                        Task.Factory.StartNew(() => action(element));
                    }
                }
            }
        }
    }
    static void Main(string[] args)    
    {
         ParallelProcessor<ParallelTask> pr = new ParallelProcessor<ParallelTask>(Environment.ProcessorCount, collection, (e) => e.Method1());
                pr.StartProcessing();
    }
