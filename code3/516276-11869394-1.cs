    public interface IDataListEntry { 
        bool QuacksLikeADuck { get; } 
        bool WalksLikeADuck { get; }
    }
    
    public abstract class DataListEntry<T> : IDataListEntry where ... {
        // Implement these in subclasses
        abstract bool QuacksLikeADuck { get; } 
        abstract bool WalksLikeADuck { get; } 
    }
