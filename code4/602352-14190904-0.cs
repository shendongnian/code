    namespace WPFTestBinding.DataAccess
    {
        class Test
        {
            public string TestID { get { return "This is my test"; } }
        }
    }
    
    public partial class MainWindow : Window
    {    
        public MainWindow()
        {
           InitializeComponent();
           DataAccess.Test testInstance = new Test();
           this.DataContext = testInstance;
        }
    }
