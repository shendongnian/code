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
            // the listView will only be updated if the changes were accepted
            // setting the result to OK will also close the dialog
            // if you wanted to add multiple items, don't set the result here,
            // but instead have another button (ex, "Apply") that does that
            // and you would then really need a List<Person>
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
