        namespace ConsoleApplication1
        {
            public enum CombineOptions
            {
                And,
                Or,
            }
            public class FilterExpression
            {
                public string Filter { get; set; }
                public CombineOptions Options { get; private set; }
                public FilterExpression(string filter, CombineOptions options)
                {
                    this.Filter = filter;
                    this.Options = options;
                }
            }
            public static class PredicateExtensions
            {
                public static Predicate<T> And<T>
                    (this Predicate<T> original, Predicate<T> newPredicate)
                {
                    return t => original(t) && newPredicate(t);
                }
                public static Predicate<T> Or<T>
                    (this Predicate<T> original, Predicate<T> newPredicate)
                {
                    return t => original(t) || newPredicate(t);
                }
            }
            public static class ExpressionBuilder
            {
                public static Predicate<string> BuildExpression(IEnumerable<FilterExpression> filterExpressions)
                {
                    Predicate<string> predicate = (delegate
                    {
                        return true;
                    });
                    foreach (FilterExpression expression in filterExpressions)
                    {
                        string nextFilter = expression.Filter;
                        Predicate<string> nextPredicate = (o => Regex.Match(o, nextFilter).Success);
                        switch (expression.Options)
                        {
                            case CombineOptions.And:
                                predicate = predicate.And(nextPredicate);
                                break;
                            case CombineOptions.Or:
                                predicate = predicate.Or(nextPredicate);
                                break;
                        }
                    }
                    return predicate;
                }
            }
            class Program
            {
                static void Main(string[] args)
                {
                    FilterExpression f1 = new FilterExpression(@"data([A-Za-z0-9\-]+)$", CombineOptions.And);
                    FilterExpression f2 = new FilterExpression(@"otherdata([A-Za-z0-9\-]+)$", CombineOptions.And);
                    FilterExpression f3 = new FilterExpression(@"otherdata([A-Za-z0-9\-]+)$", CombineOptions.Or);
                    // result will be false as "data1" does not match both filters
                    Predicate<string> pred2 = ExpressionBuilder.BuildExpression(new[] { f1, f2 });
                    bool result = pred2.Invoke("data1");
                    // result will be true as "data1" matches 1 of the 2 Or'd filters
                    Predicate<string> pred3 = ExpressionBuilder.BuildExpression(new[] { f1, f3 });
                    result = pred3.Invoke("data1");
                }
            }
        }
