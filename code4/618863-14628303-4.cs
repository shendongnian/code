    namespace ConsoleApplication
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Tuple<Expression, Expression>>  conditions = new List<Tuple<Expression, Expression>>();
                // a complex condition, that the current item contains both "B" and "H"
                Expression<Func<IEnumerable<string>, bool>> expression1 = item => item.Contains("B") && item.Contains("H");
                // an expression which is used to exclude the elements from the list
                Expression<Func<string, bool>> expression2 = j => j != "B" && j != "H";
                // associate the condition with the exclusion filter
                var condition = new Tuple<Expression, Expression>(expression1, expression2);
                conditions.Add(condition);
                List<string> strArr = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H" };
                IEnumerable<IEnumerable<string>> result = Process(strArr, conditions);
            }
            private static IEnumerable<IEnumerable<string>> Process(IEnumerable<string> strArr, List<Tuple<Expression, Expression>> conditions)
            {
                List<IEnumerable<string>> response = new List<IEnumerable<string>>();
                int k = 0;
                for (int i = 1; i <= strArr.Count(); i++)
                {
                    k++;
                    var r = strArr.Combinations(Math.Min(strArr.Count(), k));
                    bool stop=false;
                    foreach (IEnumerable<string> item in r)
                    {
                        if (stop)
                        {
                            break;
                        }
                        foreach (Tuple<Expression, Expression> condition in conditions)
                        {
                            if (Enumerable.Repeat<IEnumerable<string>>(item, 1).Any(Evaluate(condition.Item1) as Func<IEnumerable<string>, bool>))
                            {
                                var initialCount = strArr.Count();
                                strArr = strArr.Where(Evaluate(condition.Item2) as Func<string, bool>);
                                i -= initialCount - strArr.Count();
                                stop = true;
                                break;
                            }
                            else
                            {
                                foreach (var item1 in r)
                                {
                                    response.Add(item1);
                                }
                            }
                        }
                    }
                }
                return response;
            }
            public static object Evaluate(Expression e)
            {
                if (e.NodeType == ExpressionType.Constant)
                    return ((ConstantExpression)e).Value;
                return Expression.Lambda(e).Compile().DynamicInvoke();
            }
        }
        public static class Helper
        {
            public static IEnumerable<IEnumerable<T>> Combinations<T>(this IEnumerable<T> elements, int k)
            {
                return k == 0 ? new[] { new T[0] } :
                  elements.SelectMany((e, i) =>
                    elements.Skip(i + 1).Combinations(k - 1).Select(c => (new[] { e }).Concat(c))
                    );
            }
        }
    }
