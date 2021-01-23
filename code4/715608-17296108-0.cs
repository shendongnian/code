    public class Coordinator<T> where T: new()
    {
        public async Task<Tuple<IEnumerable<T>, AggregateException>> GetResultsAsync()
        {
            var tasks = new Task<T>[10];
            for(int i = 0; i < 10; i++)
            {
                tasks[i] = Task.Run(() => GetResult(i));
            }
            
            var results = new List<T>();
            var exceptions = new List<Exception>();
            foreach(var item in tasks)
            {
                try
                {
                    var result = await item;
                    results.Add(result);
                }
                catch(Exception e)
                {
                    exceptions.Add(e);
                }
            }
            
            return Tuple.Create<IEnumerable<T>, AggregateException>(results, new AggregateException(exceptions));
        }
        private T GetResult(int i)
        {
            if (i % 2 == 0) throw new Exception("Result cannot be even.");
            return new T();
        }
    }
