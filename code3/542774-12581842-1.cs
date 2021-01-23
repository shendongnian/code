    public interface IFoo
    {
        Task<int> AwaitableMethod();
    }
    class Bar
    {
        static async void AsyncMethod() // marked as async!
        {
            IFoo x;
            await x.AwaitableMethod();
        }
    }
 
