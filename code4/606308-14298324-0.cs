    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MyClass a = new MyClass(this).WriteToLabel("Test");
        }
    }
    
    class MyClass
    {
        MainWindow parent;
    
        public MyClass(MainWindow parent)
        {
            this.parent = parent;
        }
    
        public MyClass WriteToLabel(string txt)
        {
            parent.label1.Text = txt;
            return this;
        } 
    }
