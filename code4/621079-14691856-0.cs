    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel();
            Binding binding = new Binding("IsRequired")
            {
                Source = UserControl1.IsRequiredProperty,
                Mode = BindingMode.TwoWay
            };
        }
    }
    public class ViewModel : INotifyPropertyChanged
    {
        private bool isRequired;
        public bool IsRequired
        {
            get { return isRequired; }
            set { isRequired = value; Notify("IsRequired"); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void Notify(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        private CommandHandler mycommand;
        public CommandHandler MyCommand { get { return mycommand ?? (mycommand = new CommandHandler((obj) => OnAction(obj))); } }
        private void OnAction(object obj)
        {
            IsRequired = true;
        }
    }
    public class CommandHandler : ICommand
    {
        public CommandHandler(Action<object> action)
        {
            action1 = action;
        }
        Action<object> action1;
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public event EventHandler CanExecuteChanged;
        public void Execute(object parameter)
        {
            action1(parameter);
        }
    }
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty IsRequiredProperty = DependencyProperty.Register("IsRequired", typeof(bool), typeof(UserControl1), new FrameworkPropertyMetadata(default(bool)));
        public bool IsRequired
        {
            get { return (bool)GetValue(IsRequiredProperty); }
            set { SetValue(IsRequiredProperty, value); }
        }
    }
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="*"/>
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>
        <local:UserControl1></local:UserControl1>
        <Button Command="{Binding MyCommand}" Grid.Row="1" Content="Action"/>
    </Grid>
