    public partial class MainWindow : Window
    {
       public List<A> AList { get; set; }
    
       public MainWindow()
       {
          InitializeComponent();
          AList= new List<A>();
          AList.Add(new A());
          AList.Add(new A());
          AList.Add(new A());
          AList.Add(new A());
          DataContext = this;
       }
    }
