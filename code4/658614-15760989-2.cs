    public class CommandWrapper
    {
        ICommand Command {get;set;}
        string CommandName {get;set;}
    }
    
    public class CustomerViewModel
    {
        Customer Customer {get;set;}
        IEnumerable<CommandWrapper> Commands {get;}
    }
