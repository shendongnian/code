        public class Foo
        {
            public void Bar()
            {
            }
            public void Bar(string input)
            {
            }
            public bool BarReturn()
            {
                return false;
            }
        }
        public class ImportHelper<TClass>
        {
            public void Import(string name, Expression<Action<TClass>> methodExpression)
            {
                ImportMethod(name, methodExpression);
            }
            public void ImportMethodWithParam<TParam>(string name, Expression<Action<TClass, TParam>> methodExpression)
            {
                ImportMethod<TClass, TParam>(name, methodExpression);
            }
            public void ImportMethodWithResult<TResult>(string name, Expression<Func<TClass, TResult>> methodExpression)
            {
                ImportMethod<TClass, TResult>(name, methodExpression);
            }
        }
        private static void TestImport()
        {
            ImportMethod<Foo>("MyMethod", f => f.Bar());
            ImportMethod<Foo, string>("MyMethod1", (f, p) => f.Bar(p));
            ImportMethod<Foo, bool>("MyMethod2", f => f.BarReturn());
            var helper = new ImportHelper<Foo>();
            helper.Import("MyMethod", f => f.Bar());
            helper.ImportMethodWithParam<string>("MyMethod1", (f, p) => f.Bar(p));
            helper.ImportMethodWithResult("MyMethod2", f => f.BarReturn());
        }
        public static void ImportMethod<TClass>(string name, Expression<Action<TClass>> methodExpression)
        {
            var method = GetMethodInfo(methodExpression.Body as MethodCallExpression);
            //Do what you want with the method.
        }
        public static void ImportMethod<TClass, TParam>(string name, Expression<Action<TClass, TParam>> methodExpression)
        {
            var method = GetMethodInfo(methodExpression.Body as MethodCallExpression);
            //Do what you want with the method.
        }
        public static void ImportMethod<TClass, TResult>(string name, Expression<Func<TClass, TResult>> methodExpression)
        {
            var method = GetMethodInfo(methodExpression.Body as MethodCallExpression);
            //Do what you want with the method.
        }
        private static MethodInfo GetMethodInfo(MethodCallExpression methodCallExpression)
        {
            if (methodCallExpression == null)
                return null;
            return methodCallExpression.Method;
        }
