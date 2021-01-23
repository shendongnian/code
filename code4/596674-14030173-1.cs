    public partial class Form1 : Form
    {
        BindingList<Person> lstBinding;
        public Form1()
        {
            InitializeComponent();
            lstBinding = new BindingList<Person>();
            dataGridView1.DataSource = lstBinding;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                Person p = new Person();
                p.Name = textBox1.Text;
                lstBinding.Add(p);
                FillGrid();
            }
        }
        private void FillGrid()
        {
            dataGridView1.DataSource = lstBinding;
        }
    }
   
    class Person
    {
        private string name;
        public string Name 
        { 
            get {return name;}
            set { name = value; } 
        }
    }
