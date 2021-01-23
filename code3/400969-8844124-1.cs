    [ContractClassFor(typeof(IFetch<>))]
    public abstract class ContractClassForIFetch<T> : IFetch<T>
    {
        public T Fetch(int id)
        {
            Contract.Requires(id != 0);
            return default(T);
        }
    }
