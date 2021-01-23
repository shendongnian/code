    public class MyTestClass
    {
        public void Run()
        {
            List<string> myList = new List<string>() { "one", "two" };
            object myListObject = (object)myList;
            Test(myListObject);
        }
        private void Test(object myListObject)
        {
            Type myGenericType = myListObject.GetType().GetGenericArguments().First();
            MethodInfo methodToCall = typeof(MyTestClass).GetMethods().Single(
                method => method.Name.Equals("GenericMethod") && method.GetParameters().First().Name.Equals("myEnumerableArgument"));
            MethodInfo genericMethod = methodToCall.MakeGenericMethod(myGenericType);
            genericMethod.Invoke(this, new object[] { myListObject });
        }
        public void GenericMethod<T>(IQueryable<T> myQueryableArgument)
        {
        }
        public void GenericMethod<T>(IEnumerable<T> myEnumerableArgument)
        {
            GenericMethod<T>(myEnumerableArgument.AsQueryable());
        }
    }
