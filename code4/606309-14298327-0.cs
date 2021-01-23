    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MyClass a = new MyClass();
            string data = a.GetData();
            label1.Text = text;
        }
    }
    
    class MyClass
    {
        public MyClass()
        {
            this.parent = parent;
        }
    
        public stringGetData()
        {
            return "Test";
        } 
    }
