     <Grid >
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="*"/>
        </Grid.ColumnDefinitions>
        <Button Command="{Binding ClickCommand}" Width="100" Height="100" Content="wefwfwef"/>
    </Grid>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModelBase();
        }
    }
    public class ViewModelBase
    {
        public ViewModelBase()
        {
            _canExecute = true;
        }
        private ICommand _clickCommand;
        public ICommand ClickCommand
        {
            get
            {
                return _clickCommand ?? (new CommandHandler(() => MyAction(), _canExecute));
            }
        }
        private bool _canExecute;
        public void MyAction()
        {
        }
    }
    public class CommandHandler : ICommand
    {
        private Action _action;
        private bool _canExecute;
        public CommandHandler(Action action, bool canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }
        public bool CanExecute(object parameter)
        {
            return _canExecute;
        }
        public event EventHandler CanExecuteChanged;
        public void Execute(object parameter)
        {
            _action();
        }
    }
