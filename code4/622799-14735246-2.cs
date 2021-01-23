    public class CanExecuteResult
    {
        public bool CanExecute { get; set; }
        public IEnumerable<string> Messages { get; set; }
    }
    
    public interface ICommand
    {
        CanExecuteResult CanExecute();
        void Execute();
    }
    
    public class SomeCommand : ICommand
    {
        public CanExecuteResult CanExecute()
        {
            var result = new CanExecuteResult { CanExecute = true };
            var messages = new List<string>();
                
            if (SomeCondition)
            {
                result.CanExecute = false;
                messages.Add("Some reason");
            }
    
            if (AnotherCondition)
            {
                result.CanExecute = false;
                messages.Add("Another reason");
            }
    
            result.Messages = messages;
    
            return result;
        }
    
        public void Execute() { }
    }
