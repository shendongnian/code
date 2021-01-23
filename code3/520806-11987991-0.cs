    public class Command
    {
        private readonly Action<Command> _action;
    
        public Command(Action<Command> action)
        {
            _action = action;
        }
    
        public void Execute()
        {
            _action(this);
        }
    
        public void AnotherMethod()
        {
        }
    }
    
    static void Main()
    {
        var command = new Command(command =>
                      {
                          // do something
    
                          // ?? how to access and call 
                          // command.AnotherMethod(); ??
    
                          // do something else
                       });
        ....
    }
