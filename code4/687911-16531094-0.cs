    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MyClass myClass = new MyClass() { i = "a", j = "b" };
            FieldInfo[] infos = typeof(MyClass).GetFields();
            foreach (FieldInfo info in infos)
                Text += info.GetValue(myClass);
        }
    }
    
    
    class MyClass
    {
        public string i;
        public string j;
    }
