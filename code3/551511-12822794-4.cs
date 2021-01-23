    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ListBox listBox1 = new ListBox();
            MyClass obj = new MyClass();
            listBox1.DataSource = obj.NumSepaERG;
            Controls.Add(listBox1);
        }
    }
    public class MyClass
    {
        public double[] NumSepaERG { get; set; }
        public MyClass()
        {
            NumSepaERG =new double[] {2.0, 5.6};
        }
    }
