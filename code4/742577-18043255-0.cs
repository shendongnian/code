    public partial class MainWindow : Window
    {
        private readonly MyDataContext dataContext;
        private readonly DispatcherTimer timer;
        private int secondsElapsed;
        public MainWindow()
        {
            InitializeComponent();
            dataContext = new MyDataContext();
            timer = new DispatcherTimer(TimeSpan.FromSeconds(1), DispatcherPriority.ApplicationIdle, 
                TimerElapsed, Dispatcher.CurrentDispatcher);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            secondsElapsed = 0;
            timer.Start();
            MyMessageBox.Show(dataContext);
            timer.Stop();
        }
        private void TimerElapsed(object sender, EventArgs e)
        {
            dataContext.Text = string.Format("Elapsed {0} seconds.", secondsElapsed++);
        }
    }
    class MyMessageBox : Xceed.Wpf.Toolkit.MessageBox
    {
        public static MessageBoxResult Show(MyDataContext dataContext)
        {
            var messageBox = new MyMessageBox();
            messageBox.InitializeMessageBox(null, null, "Hello", MessageBoxButton.OKCancel, MessageBoxImage.Question, MessageBoxResult.Cancel);
            messageBox.SetBinding(MyMessageBox.TextProperty, new Binding
            {
                Path = new PropertyPath("Text"),
                Source = dataContext
            });
            messageBox.ShowDialog();
            return messageBox.MessageBoxResult;
        }
    }
    sealed class MyDataContext : INotifyPropertyChanged
    {
        public string Text
        {
            get { return text; }
            set
            {
                if (text != value)
                {
                    text = value;
                    OnPropertyChanged("Text");
                }
            }
        }
        private string text;
        
        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
