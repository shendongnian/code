    public static class IDAGExtensions
    {
        public static List<T> FindPathBetween(this IDAG<T> dag, int from, int to)
        {
            // Use backtracking to determine if a path exists between `from` and `to`
        }
        public static IDAG<U> Cast<U>(this IDAG<T> dag)
        {
            // Create a wrapper for the DAG class that casts all T outputs as U
        }
    }
