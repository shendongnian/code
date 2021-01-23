    public class ViewModel 
    {
        public ViewModel()
        {
            MoveCommand = new MoveCommand(this);
        }
        public Shape Shape {get;set;}
        public Point CurrentPosition {get;set;}
        public ICommand MoveCommand {get; private set;}
    }
    public class MoveCommand
    {
        ViewModel viewModel;
        Point shiftVector;
        public MoveCommand(ViewModel viewModel, Point shiftVector)
        {
            this.viewModel = viewModel;
            this.shiftVector = shiftVector;
        }
        public void Execute(object parameter)
        {
            shapeVM.CurrentPosition.X += shiftVector.X;
            shapeVM.CurrentPosition.Y += shiftVector.Y;
        }
        public void Undo()
        {
            shapeVM.CurrentPosition.X -= shiftVector.X;
            shapeVM.CurrentPosition.Y -= shiftVector.Y;
        }
    
        public bool CanExecute(object parameter)
        {
        }
    
        // Notice here: the events should be passed to the command manager to take care about it
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove {CommandManager.RequerySuggested -= value;}
        }
