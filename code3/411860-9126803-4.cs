    public partial class Form1 : Form
    {
        private Form2 form2 = new Form2();
        public Form1()
        {
            InitializeComponent();
        }
        private void buttonSettings_Click(object sender, EventArgs e)
        {
            if (form2.ShowDialog() == DialogResult.OK)
            {
                this.button1.Text = Form1Settings.ButtonText;
                this.textBoxUrl.Text = Form1Settings.Uri;
                this.Update();
            }
        }
    }
