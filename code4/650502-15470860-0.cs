    public partial class Add_Order : Form
    {
        public Add_Order()
        {
            InitializeComponent();
        }
        public List<string> GetData()
        {
            List<string> list = new List<string>();
            list.Add(textBox3.Text);
            list.Add(label6.Text);
            list.Add(textBox2.Text);
            list.Add(textBox1.Text);
            return list;
        }
    }
