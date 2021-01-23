        public class LambdaExpressionAttribute : Attribute
        {
            public LambdaExpression MyLambda { get; private set; }
            //ctor
            public LambdaExpressionAttribute(Type hostingType, string filterMethod)
            {
                MyLambda = (LambdaExpression)hostingType.GetField(filterMethod).GetValue(null);
            }
        }
        public class User
        {
            public bool IsAdministrator { get; set; }
        }
        public static class securityExpresions
        {
            public static readonly LambdaExpression IsAdministrator = (Expression<Predicate<User>>)(x => x.IsAdministrator);
            public static readonly LambdaExpression IsValid = (Expression<Predicate<User>>)(x => x != null);
            public static void CheckAccess(User user)
            {
                // only for this POC... never do this in shipping code
                System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace();
                var method = stackTrace.GetFrame(1).GetMethod();
                var filters = method.GetCustomAttributes(typeof(LambdaExpressionAttribute), true).OfType<LambdaExpressionAttribute>();
                foreach (var filter in filters)
                {
                    if ((bool)filter.MyLambda.Compile().DynamicInvoke(user) == false)
                    {
                        throw new UnauthorizedAccessException("user does not have access to: " + method.Name);
                    }
                }
            }
        }
        public static class TheClass
        {
            [LambdaExpression(typeof(securityExpresions), "IsValid")]
            public static void ReadSomething(User user, object theThing)
            {
                securityExpresions.CheckAccess(user);
                Console.WriteLine("read something");
            }
            [LambdaExpression(typeof(securityExpresions), "IsAdministrator")]
            public static void WriteSomething(User user, object theThing)
            {
                securityExpresions.CheckAccess(user);
                Console.WriteLine("wrote something");
            }
        }
        static void Main(string[] args)
        {
            User u = new User();
            try
            {
                TheClass.ReadSomething(u, new object());
                TheClass.WriteSomething(u, new object());
            }
            catch(Exception e) 
            {
                Console.WriteLine(e);
            }
        }
