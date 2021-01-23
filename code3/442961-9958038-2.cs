    public partial class Form1 : Form
    {
        private BindingList<SomeClass> _data = new BindingList<SomeClass>();
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = _data;
            _data.Add(new SomeClass() { First = "1", Second = "1", Third = "1" });
            _data.Add(new SomeClass() { First = "2", Second = "2", Third = "2" });
            _data.Add(new SomeClass() { First = "3", Second = "3", Third = "3" });
            _data.Add(new SomeClass() { First = "4", Second = "4", Third = "4" });
            _data.Add(new SomeClass() { First = "5", Second = "5", Third = "5" });
            _data.Add(new SomeClass() { First = "6", Second = "6", Third = "6" });
            _data.Add(new SomeClass() { First = "7", Second = "7", Third = "7" });
            _data.Add(new SomeClass() { First = "8", Second = "8", Third = "8" });
        }
        private void button1_Click(object sender, EventArgs e)
        {
            _data.Clear();
            _data.Add(new SomeClass() { First = "11", Second = "11", Third = "11" });
            _data.Add(new SomeClass() { First = "21", Second = "21", Third = "21" });
            _data.Add(new SomeClass() { First = "31", Second = "31", Third = "31" });
        }
    }
    public class SomeClass
    {
        public string First { get; set; }
        public string Second { get; set; }
        public string Third { get; set; }
    }
