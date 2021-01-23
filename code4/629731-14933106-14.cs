    class Program
    {
       static void Main()
        {
            //sample expression
            Expression<Func<IPerson, bool>> expression = x => x.Prop;
            //parameter that will be used in generated expression
            var param = Expression.Parameter(typeof(PersonData));
            //visiting body of original expression that gives us body of the new expression
            var body = new Visitor<PersonData>(param).Visit(expression.Body);
            //generating lambda expression form body and parameter 
            //notice that this is what you need to invoke the Method_2
            Expression<Func<PersonData, bool>> lambda = Expression.Lambda<Func<PersonData, bool>>(body, param);
            //compilation and execution of generated method just to prove that it works
            var boolValue = lambda.Compile()(new PersonData());
        }
    }
