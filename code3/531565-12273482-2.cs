    public class FormA : Form
    {
        public FormA()
        {
            InitializeComponent();
        }
        public void buttonClick(object sender, EventArgs e)
        {
            FormB formB = new FormB(this);
            formB.Show();
        }
    }
