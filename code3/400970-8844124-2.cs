    [ContractClass(typeof(ContractClassForIFetch<>))]
    public interface IFetch
    {
        T Fetch(int id);
    }
