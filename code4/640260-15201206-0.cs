    public interface IChunk
    {
        // whatever
    }
    public interface IProcessInParallel
    {
        void Execute<T>(Func<IEnumerable<IEnumerable<IChunk>>> getChunks) where T : IProcessInParallelTask;
    }
