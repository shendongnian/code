    public class Client 
    {
        public void DoSomethingWith<T>() where T : ICommandThatHasProduct, new()
        {
            var command = new T();
            var products = command.GetProducts();
        }
    }
