        public partial class MainPage : UserControl
        {
           public ObservableCollection<Test> Tests { get; set; }
    
           public MainPage()
           {
               InitializeComponent();
            
               DataContext = this;
    
               Tests = new ObservableCollection<Test>();
               Tests.Add(new Test() { Label = "Test1" });
               Tests.Add(new Test() { Label = "Test2" });
               Tests.Add(new Test() { Label = "Test3" });
               Tests.Add(new Test() { Label = "Test4" });
           }
        }
