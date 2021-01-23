     public partial class MainWindow : Window, INotifyPropertyChanged
        {
            public MainWindow()
            {
                InitializeComponent();
                this.DataContext = this;
            }
            
            public string myText { get; set; }
    
            public void Button_Click_1(object sender, RoutedEventArgs e)
            {
                BackgroundWorker bw = new BackgroundWorker();
                bw.DoWork += delegate
                {
                    int i = 0;
                    for (i = 0; i < 100; i++)
                    {
                        System.Windows.Threading.Dispatcher.CurrentDispatcher.Invoke((Action)(() => { myText = i.ToString(); OnPropertyChanged("myText"); }));                    
                        Thread.Sleep(100);
                    }
                };
    
                bw.RunWorkerAsync();
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected void OnPropertyChanged(string name)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(name));
                }
            }
        }
