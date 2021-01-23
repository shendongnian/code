     public partial class Form1 : Form
    {
        Person[] listPersons = new Person[0];
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = listPersons;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                Person p = new Person();
                p.Name = textBox1.Text;
                Array.Resize<Person>(ref listPersons, listPersons.Length+1);
                listPersons[listPersons.Length-1]=p;
                dataGridView1.DataSource = listPersons;
            }
        }
    }
    class Person
    {
        public string Name { get; set; }
    }
