    //Represents an oriented one-way mapper
    public interface IDirectionalMapper<A, B>
    {
        B Map(A obj);
    }
    //Represents an oriented two-way mapper
    public interface IBidirectionalMapper<A, B>
        : IDirectionalMapper<A, B>, IDirectionalMapper<B, A>
    {
    }
    //Represents an unoriented two-way mapper
    public interface IUndirectedMapper<A, B>
        : IBidirectionalMapper<A, B>, IBidirectionalMapper<B, A>
    {
    }
