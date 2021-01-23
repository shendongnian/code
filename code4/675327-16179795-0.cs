    public abstract class Token : IComparable
    {
        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return -1;
            }
            return GetType().FullName.CompareTo(obj.GetType().FullName);
        }
    }
    public class WordToken : Token { }
    public class VariableToken : Token { }
    
    public static class ListExtensions
    {
        public static IEnumerable<IEnumerable<TEntity>> JoinRepeatedValues<TEntity>(this IEnumerable<TEntity> collection)
            where TEntity : IComparable
        {
            var joinedRepeatedValuesCollection = new List<List<TEntity>>();
            var lastValue = default(TEntity);
            foreach (var item in collection)
            {
                if (item.CompareTo(lastValue) != 0)
                {
                    joinedRepeatedValuesCollection.Add(new List<TEntity> { item });
                }
                else
                {
                    var lastAddedValue = joinedRepeatedValuesCollection.Last();
                    lastAddedValue.Add(item);
                }
                lastValue = item;
            }
            return joinedRepeatedValuesCollection;
        }
    
    }
    class Program
    {
        static void Main(string[] args)
        {
            var tokens = new Token[]
                                {
                                    new WordToken(),
                                    new WordToken(),
                                    new VariableToken(),
                                    new WordToken(),
                                    new WordToken(),
                                    new WordToken(),
                                    new VariableToken(),
                                    new WordToken()
                                };
    
            var joinedValues = tokens.JoinRepeatedValues();
            var items = new[] { "1", "1", "1", "1", "1", "varX", "1", "1", "1", "1", "varY", "1", "1" }.JoinRepeatedValues();
        }
    }
