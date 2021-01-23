    public sealed class MyClass
    {
        public MyClass()
        {
            MyProperty = new AsyncLazy<int>(async () =>
            {
                await Task.Delay(100);
                return 13;
            });
        }
        public AsyncLazy<int> MyProperty { get; private set; }
    }
