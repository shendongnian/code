    public partial class add : Form
    {
        // notice that we don't need a List, just a single item
        public Person person = new Person();
        public add()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.person.Name = this.nameTextBox.Text;
            this.person.Surname = this.surnameTextBox.Text;
            // the listView is only be updated if the changes were accepted
            // setting the result to OK will also close the dialog
            this.DialogResult = DialogResult.OK;
        }
    }
