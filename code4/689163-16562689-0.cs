        public partial class MainClass : Form
        {
            public MainClass()
            {
                InitializeComponent();
            }
    
            public string UserName
            {
                get { return textBox1.Text }
                set { textBox1.Text = value; }
            }
    
            public bool IsChecked
            {
                get { return checkBox1.Checked; }
                set { checkBox1.Checked = value; }
            }
        }
    
        public class AnotherClass
        {
            public void MyFunc()
            {
                MainClass obj = new MainClass();
                obj.UserName = "SomeUser1";
                obj.IsChecked = true;
            }
        }
