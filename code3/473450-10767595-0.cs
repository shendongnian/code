    public partial class MainWindow : Window, IListner
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void Send(string message)
        {
            // Read the message here.
            // If this code is called from different thread, use "Dispatcher.Invoke()"
        }
        public void OpenAnotherWindow()
        {
            // Since "MainWindow" implements "IListner", it can pass it's own instance to "ChildWindow"
            ChildWindow childWindow = new ChildWindow(this);
        }  
    }
