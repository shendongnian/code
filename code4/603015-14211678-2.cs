    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window 
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    
        private int myVar = 700;
        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }
    
        public void TestMethod1()
        {
    
        }
    
        public void TestMethod2(int value)
        {
    
        }
    
        public void TestMethod3(string value)
        {
    
        }
    }
