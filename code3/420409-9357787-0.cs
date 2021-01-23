    public interface ICommandService
    {
        void RegisterCommand(string name, ICommand command);
        ICommand this[string name] {get;}
    }
    public class OuterViewModel
    {
        public OuterViewModel (ICommandService commandService)
        {
            commandService.RegisterCommand("OpenNewTab", OpenNewTab);
        }
        
        private void OpenNewTab (object newTabViewModel)
        {
             // The new tab's viewmodel is sent as the ICommand's CommandParameter
        }
    }
    public class InnerViewModel
    {
        public InnerViewModel (ICommandService commandService)
        {
            _commandService = commandService; // Save injected service locally.
        }
        public HandleClickOnInnerTabpage()
        {
             AnotherViewModel newVM = new AnotherViewModel(...);
             _commandService["OpenNewTab"].Execute(newVM);
        }
    }
