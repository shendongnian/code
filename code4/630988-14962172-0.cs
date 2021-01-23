    public interface IPosterGenerator 
    {
        IQueryable GetPosters();
    }
    public interface IPosterGenerator<T> :
        IPosterGenerator 
    {
        IQueryable<T> GetPosters();
    }
