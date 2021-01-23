    public class Sample
    {
        public int Person1 { get; set; }
        public int Person2 { get; set; }
        public int Person3 { get; set; }
    }
    
    static void Main(string[] args) {
        var s = new  Sample();
        var tuples = new List<Tuple<string, int>> { 
                        Tuple.Create("Person1", 1), 
                        Tuple.Create("Person2", 2), 
                        Tuple.Create("Person3", 3) 
                     };
        var argument = Expression.Constant(s);
        foreach (var item in tuples) {
            CreateLambda(item.Item1, argument, item.Item2)
                   .Compile()
                   .DynamicInvoke();
        }
     }
    static LambdaExpression CreateLambda(string propertyName, Expression instance, int value) {
         return Expression.Lambda(
                   Expression.Assign(
                      Expression.PropertyOrField(instance, propertyName), 
                      Expression.Constant(value)));
     }
