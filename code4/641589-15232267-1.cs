    // the type being evaluated
    public class Foo
    {
        public string Bar {
            get;
            set;
        }
    }
    // method in an evaluator class
    public TProperty EvaluateProperty<TProperty>( Expression<Func<Foo, TProperty>> expression ) {
        string propertyToGetName = ( (MemberExpression)expression.Body ).Member.Name;
        // do something with the property name
        // and/or evaluate the expression and get the value of the property
        return expression.Compile()( null );
    }
