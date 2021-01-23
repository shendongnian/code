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
            var workerThread = new BackgroundWorker();
            workerThread.DoWork += new DoWorkEventHandler((object sender, DoWorkEventArgs e) =>
            {
                vm.StartLoadingData(10000);
            });
            workerThread.RunWorkerAsync();
        }
    }
    public class MainPageViewModel
    {
        public ObservableCollection<TestClass> ListOfTestClasses { get; set; }
        public MainPageViewModel()
        {
            ListOfTestClasses = new ObservableCollection<TestClass>();
        }
        public void StartLoadingData(int numberOfElements)
        {
            for (int i = 0; i < numberOfElements; i++)
            {
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    ListOfTestClasses.Add(new TestClass { Text = "Element " + (i + 1) });
                });
                Thread.Sleep(150);
            }
        }
    }
    public class TestClass
    {
        public string Text { get; set; }
    }
