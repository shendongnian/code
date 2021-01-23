    public class Client 
    {
        public void DoSomethingWith(ICommandThatHasProduct command)
        { 
            var products = command.GetProducts();
        }
    }
