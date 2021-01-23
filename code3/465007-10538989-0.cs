    public interface ISearcher<T>
    {
        IEnumerable<T> Search();
    }
    public class GeneralSearch<T> : ISearcher<T> where T : new()
    {
        public static IEnumerable<T> Search()
        {
            var list = new List<T> { new T(), new T(), new T() };
            return list;
        }
    }
