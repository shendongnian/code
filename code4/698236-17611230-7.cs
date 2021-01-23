    class Program
    {
        static void Main(string[] args)
        {
            var propertyInfo1FromReflection = typeof(MyClass).GetProperty("EmployeeId");
            var propertyInfo2FromReflection = typeof(MyClass).GetProperty("EmployeeNumber");
            var e1 = MyClass.Relationships[0].Item1;
            foreach (var relationship in MyClass.Relationships)
            {
                var body1 = (UnaryExpression)relationship.Item1.Body;
                var operand1 = (MemberExpression)body1.Operand;
                var propertyInfo1FromExpression = operand1.Member;
                var body2 = (UnaryExpression)relationship.Item2.Body;
                var operand2 = (MemberExpression)body2.Operand;
                var propertyInfo2FromExpression = operand2.Member;
                Console.WriteLine(propertyInfo1FromExpression.Name);
                Console.WriteLine(propertyInfo2FromExpression.Name);
                Console.WriteLine(propertyInfo1FromExpression == propertyInfo1FromReflection);
                Console.WriteLine(propertyInfo2FromExpression == propertyInfo2FromReflection);
            }
        }
    }
