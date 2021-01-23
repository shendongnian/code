        class Program {
           static void Main(string[] args) {
              var location = new Location();
              Expression<Func<Employee, bool>> expression = e => e.Location == location;
              var untypedBody = expression.Body;
              //The untyped body is a BinaryExpression
               Debug.Assert(
                  typeof(BinaryExpression).IsAssignableFrom(untypedBody.GetType()), 
                  "Not Expression.Equal");
               var body = (BinaryExpression)untypedBody;
               var untypedLeft = body.Left;
               var untypedRight = body.Right;
               //The untyped left expression is a MemberExpression
               Debug.Assert(
                  typeof(MemberExpression).IsAssignableFrom(untypedLeft.GetType()), 
                  "Not Expression.Property");
               ////The untyped right expression is a ConstantExpression
              //Debug.Assert(
              //   typeof(ConstantExpression).IsAssignableFrom(untypedRight.GetType()),                 
              //   "Not Expression.Constant");
              //The untyped right expression is a MemberExpression?
              Debug.Assert(
                   typeof(MemberExpression).IsAssignableFrom(untypedRight.GetType())));
        }
    }
    public class Employee
    {
        public Location Location { get; set; }
    }
    public class Location { }
