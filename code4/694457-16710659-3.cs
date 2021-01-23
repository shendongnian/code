    [AwesomeFoo]
    static class Program
    {
        static void Main()
        {
            var foo = (FooAttribute)Attribute.GetCustomAttribute(
                typeof(Program), typeof(FooAttribute));
            if (foo != null)
            {
                int[] nums = foo.Nums; // 1,2,3
            }
        }
    }
