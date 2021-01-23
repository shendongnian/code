    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            Form1Settings.ButtonText = this.textBoxButton.Text;
            Form1Settings.Uri = this.textBoxUri.Text;
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }
    }
