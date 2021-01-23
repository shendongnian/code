    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MyClass a = new MyClass(this);
            a.WriteToLabel();
        }
    
        public string LabelText
        {  
            get { return label1.Text; }
            set {
                    if (this.InvokeRequired) 
                    {
                       this.BeginInvoke(
                           delegate() => 
                                    { 
                                      label1.Text =value;
                                    })};
                     }
                     else
                     {
                        label1.Text = value;
                     }
                  }
    }
    
    class MyClass
    {
        MainWindow parent;
    
        public MyClass(MainWindow parent)
        {
            this.parent = parent;
        }
        public void WriteToLabel()
        {
            parent.LabelText = "Test";
        } 
    }
