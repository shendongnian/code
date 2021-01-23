    class Program
    {
       static void Main()
        {
            Expression<Func<IPerson, bool>> expression = x => x.Prop;
            var param = Expression.Parameter(typeof(PersonData));
            var result = new Visitor<PersonData>(param).Visit(expression.Body);
            var lambda = Expression.Lambda<Func<PersonData, bool>>(result, param);
            var boolValue = lambda.Compile()(new PersonData());
        }
    }
