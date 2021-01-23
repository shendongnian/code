    myFoo.Select(x=>x.GetBars()).Flatten().Select(bar => bar.Name)
---
    public static class ParallelExtensions
    {
        public static IEnumerable<T> Flatten<T>(this IEnumerable<IEnumerable<T>> enumOfEnums)
        {
            BlockingCollection<T> queue = new BlockingCollection<T>();
            Task.Factory.StartNew(() =>
            {
                Parallel.ForEach(enumOfEnums, e =>
                {
                    foreach (var x in e)
                    {
                        queue.Add(x);
                    }
                });
                queue.CompleteAdding();
            });
            return queue.GetConsumingEnumerable();
        }
    }
