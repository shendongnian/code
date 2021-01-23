    public interface IDAG<out T>
    {
        public int NodeCount { get; }
        public bool AreConnected(int from, int to);
        public T GetItem(int node);
    }
    public class DAG<T> : IDAG<T>
    {
        public void SetCount(...) {...}
        public void SetEdge(...) {...}
        public int NodeCount { get {...} }
        public bool AreConnected(...) {...}
        public T GetItem(...) {...}
    }
