    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormCollection frms = Application.OpenForms;
            foreach (Form f in frms)
            {
                if (f.Name == "Form1")
                {
                    f.Show();
                    break;
                }
            }
        }
    }
