    [AwesomeFoo]
    static class Program
    {
        static void Main()
        {
            var foo = (FooAttribute)Attribute.GetCustomAttribute(
                typeof(Program), typeof(AwesomeFooAttribute));
            if (foo != null)
            {
                int[] nums = foo.Nums; // 1,2,3
            }
        }
    }
