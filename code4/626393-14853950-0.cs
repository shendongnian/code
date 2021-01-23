    class Program
    {
        public enum Operator
        {
            And,
            Or
        }
        public class Condition
        {
            public Operator Operator { get; set; }
            public string FieldName { get; set; }
            public object Value { get; set; }
        }
        public class DatabaseRow
        {
            public int A { get; set; }
            public string B { get; set; }
        }
        static void Main(string[] args)
        {
            var conditions = new List<Condition>
            {
                new Condition { Operator = Operator.And, FieldName = "A", Value = 1 },
                new Condition { Operator = Operator.And, FieldName = "B", Value = "Asger" },
                new Condition { Operator = Operator.Or, FieldName = "A", Value = 2 },
            };
            var currentExpr = MakeExpression(conditions.First());
            foreach (var condition in conditions.Skip(1))
            {
                var nextExpr = MakeExpression(condition);
                switch (condition.Operator)
                {
                    case Operator.And:
                        currentExpr = Expression.And(currentExpr, nextExpr);
                        break;
                    case Operator.Or:
                        currentExpr = Expression.Or(currentExpr, nextExpr);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
        static BinaryExpression MakeExpression(Condition condition)
        {
            return Expression.Equal(
                Expression.MakeMemberAccess(Expression.Parameter(typeof (DatabaseRow)),
                                            typeof (DatabaseRow).GetMember(condition.FieldName)[0]),
                Expression.Constant(condition.Value));
        }
    }
