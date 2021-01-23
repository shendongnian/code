    public interface ICommand
    {
        IEnumerable<string> Messages { get; }
        bool CanExecute();
        void Execute();
    }
    
    public class SomeCommand : ICommand
    {
        public IEnumerable<string> Messages { get; private set; }
    
        public bool CanExecute()
        {
            var messages = new List<string>();
                
            var canExecute = true;
    
            if (SomeCondition)
            {
                canExecute = false;
                messages.Add("Some reason");
            }
    
            if (AnotherCondition)
            {
                canExecute = false;
                messages.Add("Another reason");
            }
    
            Messages = messages;
    
            return canExecute;
        }
    
        public void Execute() { }
    }
