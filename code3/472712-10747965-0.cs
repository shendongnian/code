    public class foo
    {
        public void SomeMethod(Type type)
        {
            var methodInfo = this.GetType().GetMethod("SomeGenericMethod");
            var method = methodInfo.MakeGenericMethod(new[] { type });
            method.Invoke(this, null);
        }
        public void SomeGenericMethod<T>()
        {
            Debug.WriteLine(typeof(T).FullName);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var foo = new foo();
            foo.SomeMethod(typeof(string));
            foo.SomeMethod(typeof(foo));
        }
    }
