    public class ExampleCommand : CommandBase
    {
        public ExampleCommand (PropertyChangedBase viewModel)
        {
            this.ViewModel = viewModel;
        }
    
        public override void Execute(object o)
        {
            // something like
            var settings = UnityContainer.Resolve<ISettings>();
            settings.MagicValue = (this.ViewModel as ConcreteViewModel).MagicValue;
        }
    
        public override bool CanExecute(object o)
        {
            return true;
        }
    }
    
