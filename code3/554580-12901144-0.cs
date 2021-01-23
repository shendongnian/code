    <ListBox x:Name="lb">
            <ListBoxItem>
                <Button x:Name="btn" CommandParameter="btn" Command="{Binding MyCommand}" VerticalAlignment="Bottom" Height="30"/>
            </ListBoxItem>
            <ListBoxItem>
                <Button  CommandParameter="{Binding SelectedIndex, ElementName=lb}" Command="{Binding MyCommand}" VerticalAlignment="Bottom" Height="30"/> 
            </ListBoxItem>
        </ListBox>
     public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        private ICommand _myCommand;
        public ICommand MyCommand { get { return _myCommand ?? (new CommandHandler((o) => FireCommand(o),()=> true)); } }
        public void FireCommand(object obj)
        {
            var a = lb.SelectedIndex; 
        }
    public class CommandHandler:ICommand
    {
            private Action<object> del;
            public CommandHandler(Action<object> action, Func<bool> b=null)
            {
                del = action;
            }
            #region ICommand Members
            public bool CanExecute(object parameter)
            {
                return true;
            }
            public event EventHandler CanExecuteChanged;
            public void Execute(object parameter)
            {
                del(parameter);
            }
            #endregion
    }
