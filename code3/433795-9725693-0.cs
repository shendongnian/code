    interface ITimeSeries<T>
    {
        void DoWork(IEnumerable<T> timeSeries);
        int ResultsCount();
        IDictionary<int, IEnumerable<T>> Results(); // key is # of result set and IEnumerable is the results for that set
    }
