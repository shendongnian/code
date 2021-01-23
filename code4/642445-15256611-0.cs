    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(Class1 c)
        {
            InitializeComponent();
            Class1 c_1 = new Class1();
            c_1 = c;
        }
    }
    public class Class1
    {
        // Your code for Class1
    }
