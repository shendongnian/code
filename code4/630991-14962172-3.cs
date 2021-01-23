    public interface IPosterGenerator 
    {
        IQueryable GetPosters();
    }
    public interface IPosterGenerator<T> :
        IPosterGenerator 
    {
        new IQueryable<T> GetPosters();
    }
