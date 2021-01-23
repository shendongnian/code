    // Check the "out" keyword in the generic parameter!
    // "out" makes the T parameter covariant.
    public interface IPosterGenerator<out T> where T : BasePoster
    {
         IQueryable<T> GetPosters();
    }
