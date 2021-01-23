    public class EnumerableWrapper<T> : IEnumerable<T>
    {
        private IEnumerable<T> source;
        public EnumerableWrapper(IEnumerable<T> source)
        {
            this.source = source;
        }
    
        public int IterationsStarted { get; private set; }
        public int NumMoveNexts { get; private set; }
        public int IterationsFinished { get; private set; }
    
        public IEnumerator<T> GetEnumerator()
        {
            IterationsStarted++;
    
            foreach (T item in source)
            {
                NumMoveNexts++;
                yield return item;
            }
    
            IterationsFinished++;
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    
        public override string ToString()
        {
            return string.Format(
    @"Iterations Started: {0}
    Iterations Finished: {1}
    Number of move next calls: {2}"
    , IterationsStarted, IterationsFinished, NumMoveNexts);
    
        }
    }
