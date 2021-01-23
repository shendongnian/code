    public partial class Form1 : Form
    {
        List<People> people = new List<People>();
        public Form1()
        {
            InitializeComponent();
            people.Add(new People("Joe Montana"));
            people.Add(new People("Alex Smith"));
            people.Add(new People("Colin Kaepernick"));
            foreach (People p in people)
            {
                this.listBox1.Items.Add(p.Name);
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.textBox1.Text = people[listBox1.SelectedIndices[0]].Name;
        }
    }
    class People
    {
        public People(string Name)
        {
            this.Name = Name;
        }
        public string Name
        {
            get;
            set;
        }
    }
