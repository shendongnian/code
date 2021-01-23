    public interface IPosterGenerator
    {
    }
    public interface IPosterGenerator<T> : IPosterGenerator
    {
        IQueryable<T> GetPosters();
    }
    public class Pinboard
    {
        public Pinboard(List<IPosterGenerator> generators) 
        {
        }
    }
