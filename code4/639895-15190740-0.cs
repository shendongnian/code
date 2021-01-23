    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.listBox1.DataSource = new List<int> { 1, 2, 3, 4 };
        }
    }
