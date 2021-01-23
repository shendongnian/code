    public class MainWindowViewModel : INotifyPropertyChanged
    {
       private object _currentWorkspace; //instead of object type you can use a base class or interface
       public object CurrentWorkspace
       {
          get { return this._currentWorkspace; }
          set { this._currentWorkspace = value; OnPropertyChanged("CurrentWorkspace"); }
       }
       public MainWindowViewModel()
       {
          CurrentWorkspace= new EditUserControlViewModel();
       }
       //todo: to switch the workspace create DelegeCommand/RelayCommand and set the CurrentWorkspace
       //if you dont know about these commands let me know and i post it
       public ICommand SwitchToViewCommand {get{...}}
       public ICommand SwitchToEditCommand {get{...}}
    }
