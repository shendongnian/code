    public class GenericCommand : ICommand
    {
        public event EventHandler CanExecuteChanged { add{} remove{} } 
        public Predicate<object> CanExecuteFunc{ get; set; }
        public Action<object> ExecuteFunc{ get; set; }
        public bool CanExecute(object parameter)
        {
            return CanExecuteFunc(parameter);
        }
        public void Execute(object parameter)
        {
            ExecuteFunc(parameter);
        }
    }
