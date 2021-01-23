    namespace
    {
        public interface ICommand
        {
            public void Execute();
        }
    
        public class CommandA : ICommand
        {
            public int value;
    
            public void Execute()
            {
                // Do something here
            }
        }
    
        public class CommandB : ICommand
        {
            public string value;
    
            public void Execute()
            {
                // Do something here
            }
        }
    
        public class Program
        {
            private Queue<ICommand> commands = new Queue<ICommand>();
    
            public Program()
            {
                this.commands.Enqueue(new CommandA());
                this.commands.Enqueue(new CommandB());
    
                // Much later
                while (item = this.commands.Dequeue())
                {
                    item.Execute();
                }
            }
        }
    }
