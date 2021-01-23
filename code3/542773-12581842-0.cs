    public interface IFoo
    {
        Task<int> AwaitableMethod();
    }
    class Program
    {
        static async void Main(string[] args) // marked as async!
        {
            IFoo x;
            await x.AwaitableMethod();
        }
    }
 
