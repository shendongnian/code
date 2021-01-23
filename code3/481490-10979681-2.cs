    public static class QueryExtensions
    {
        public static IEnumerable<TSource> Where<TSource>(this Repo<TSource> source, Expression<Func<TSource, bool>> predicate)
        {
            // hacks all the way
            dynamic operation = predicate.Body;
            dynamic left = operation.Left;
            dynamic right = operation.Right;
            var ops = new Dictionary<ExpressionType, String>();
            ops.Add(ExpressionType.Equal, "=");
            ops.Add(ExpressionType.GreaterThan, ">");
            // add all required operations here            
            // Instead of SELECT *, select all required fields, since you know the type
            var q = String.Format("SELECT * FROM {0} WHERE {1} {2} {3}", typeof(TSource), left.Member.Name, ops[operation.NodeType], right.Value);
            return source.RunQuery(q);
        }
    }
    public class Repo<T>
    {
        internal IEnumerable<T> RunQuery(string query)
        {
            return new List<T>(); // run query here...
        }
    }
    public class TestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var repo = new Repo<TestModel>();
            var result = repo.Where(e => e.Name == "test");
            var result2 = repo.Where(e => e.Id > 200);
        }
    }
