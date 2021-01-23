    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            /* In the xaml code:
               <ListBox x:Name="ChannelsListBox" ItemsSource="{Binding ListOfTestClasses}" ...
            */
            var vm = new MainPageViewModel();
            DataContext = vm;
            vm.StartLoadingDataAsync(10000);
        }
    }
    public class MainPageViewModel
    {
        public ObservableCollection<TestClass> ListOfTestClasses { get; set; }
        private BackgroundWorker workerThread;
        public MainPageViewModel()
        {
            ListOfTestClasses = new ObservableCollection<TestClass>();
            workerThread = new BackgroundWorker();
            workerThread.DoWork += new DoWorkEventHandler((object sender, DoWorkEventArgs e) =>
            {
                for (int i = 0; i < (int)e.Argument; i++)
                {
                    Deployment.Current.Dispatcher.BeginInvoke(() =>
                    {
                        ListOfTestClasses.Add(new TestClass { Text = "Element " + (i + 1) });
                    });
                    Thread.Sleep(150);
                }
            });
        }
        public void StartLoadingDataAsync(int numberOfElements)
        {
            workerThread.RunWorkerAsync(numberOfElements);   
        }
    }
    public class TestClass
    {
        public string Text { get; set; }
    }
