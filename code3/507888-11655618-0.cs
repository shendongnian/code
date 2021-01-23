    public abstract class MyCommandBase : ICommand
    {
        public abstract bool CanExecute(object o);
        public abstract void Execute(object o);
        public MyViewModel ViewModel { get; set; }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
    public class ButtonClickCommand : MyCommandBase
    {
        public ButtonClickCommand(MyViewModel vm)
        {
            base.ViewModel = vm;
        }
        public override bool CanExecute(object o)
        {
            return true;
        }
        public override void Execute(object o)
        {
            var context = this.ViewModel as MyViewModel;
            MessageBox.Show("Button was clicked for" + context.Id);
        }
    }
