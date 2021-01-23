    public partial class add : Form
    {
        public Person person = new Person();
        public add()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.person.Name = this.nameTextBox.Text;
            this.person.Surname = this.surnameTextBox.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
