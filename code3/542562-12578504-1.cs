    public interface IChainElement<T> where T : IChainElement<T>
    {
        T Previous { get; set; }
        T Next { get; set; }
    }
