    public class Foo
    {
        private int _value;
        private TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                var oldTCS = tcs;
                tcs = new TaskCompletionSource<bool>();
                oldTCS.SetResult(true);
            }
        }
    
    
        public Task ValueChanged()
        {
            return tcs.Task;
        }
    }
    
    private static void Main(string[] args)
    {
        Foo foo = new Foo();
        foo.ValueChanged()
            .ContinueWith(t =>
            {
                Console.WriteLine(foo.Value);
            }, TaskContinuationOptions.ExecuteSynchronously);
    
        foo.Value = 5;
    }
