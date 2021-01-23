    public class FormB : Form
    {
        private FormA parent;
        public FormB(FormA parent)
        {
            InitializeComponent();
            this.parent = parent;
        }
        public void buttonClick(object sender, EventArgs e)
        {
            myTextBox.Text = parent.myCheckBox.Text;
        }
    }
