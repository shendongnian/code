    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            var add = new add();
            if (add.ShowDialog() == DialogResult.OK)
            {
                this.listView1.Items.Add(add.person.Name +
                                         " " + add.person.Surname);
            }
        }
    }
