public class RelayCommand<T> : ICommand
{
    #region Fields
    readonly Action<T> _execute = null;
    readonly Predicate<T> _canExecute = null;
    #endregion
    #region Constructors
    /// <summary>
    /// Initializes a new instance of <see cref="DelegateCommand{T}"/>.
    /// </summary>
    /// <param name="execute">Delegate to execute when Execute is called on the command.  This can be null to just hook up a CanExecute delegate.</param>
    /// <remarks><seealso cref="CanExecute"/> will always return true.</remarks>
    public RelayCommand(Action<T> execute)
        : this(execute, null)
    {
    }
    /// <summary>
    /// Creates a new command.
    /// </summary>
    /// <param name="execute">The execution logic.</param>
    /// <param name="canExecute">The execution status logic.</param>
    public RelayCommand(Action<T> execute, Predicate<T> canExecute)
    {
        if (execute == null)
            throw new ArgumentNullException("execute");
        _execute = execute;
        _canExecute = canExecute;
    }
    #endregion
    #region ICommand Members
    ///<summary>
    ///Defines the method that determines whether the command can execute in its current state.
    ///</summary>
    ///<param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
    ///<returns>
    ///true if this command can be executed; otherwise, false.
    ///</returns>
    public bool CanExecute(object parameter)
    {
        return _canExecute == null ? true : _canExecute((T)parameter);
    }
    ///<summary>
    ///Occurs when changes occur that affect whether or not the command should execute.
    ///</summary>
    public event EventHandler CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }
    ///<summary>
    ///Defines the method to be called when the command is invoked.
    ///</summary>
    ///<param name="parameter">Data used by the command. If the command does not require data to be passed, this object can be set to <see langword="null" />.</param>
    public void Execute(object parameter)
    {
        _execute((T)parameter);
    }
    #endregion
}
That example came from this question https://stackoverflow.com/questions/22285866/why-relaycommand
Once you have a RelayCommand class, in your ViewModel you can define commands such as
 public class MainWindowViewModel
 {
       private ICommand _Command;
        public ICommand Command
        {
            get
            {
                if (_Command == null)
                    _Command = new RelayCommand<object>((x) => ExecuteCommand(x));
                return _Command;
            }
            set
            {
                _Command = value;
            }
        }
       private void ExecuteCommand(object parameter)
        {
            try
            {
                if (!string.IsNullOrEmpty(parameter.ToString()){
                  //Do sql call here. parameter.ToString() is a string representation of the parameter that was bound on the xaml
               }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
Now that you have that set up, just set your view's data context to the view model. You can do this in the code behind, or in the xaml, whatever you want. Something like
    public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
Now your binding in xaml to the command should look like:
<Button x:Name="myButton" Content="update" Command="{Binding Command}"     CommandParameter="{Binding assignment_id}"></Button>
However while we're here, please change your sql command to use parameters instead of concatenating it as a string like that. Doing it the way you are now will leave you open to sql injection.
Edit: it should be noted that the object you are binding to the CommandParameter should exist in your view model as well. Ideally you would have a model containing the property for assignment_id then you would instantiate a type of that model in the view model, then bind that instance of the model to your View. 
