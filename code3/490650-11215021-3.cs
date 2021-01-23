    namespace WpfApplication3
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            List<string> pending = new List<string> {"1","2"};
            List<string> busy = new List<string> { "4", "5" };
            List<string> completed = new List<string> { "7", "8" };
    
            private List<Tasks> MyTasks()
            {
                List<Tasks> tasks = new List<Tasks>();
                tasks.Add(new Tasks {Status = "Pending", Queue = pending});
                tasks.Add(new Tasks {Status = "Busy",Queue = busy});
                tasks.Add(new Tasks {Status = "Completed", Queue = completed});
                return tasks;
            }
    
            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                ICollectionView _tasksView = CollectionViewSource.GetDefaultView(MyTasks());
                _tasksView.GroupDescriptions.Add(new PropertyGroupDescription("Status"));
                lbxTasks.ItemsSource = _tasksView;
            }
        }
    
        public class Tasks
        {
            public List<string> Queue { get; set; }
            public string Status { get; set; }
        }
    }
