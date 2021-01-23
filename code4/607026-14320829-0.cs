    public partial class Combat : Form
    {
        private form1 form;    // Or whatever class you form1 is supposed to be
        public Combat(Form form)
        {
            InitializeComponent();
            this.form = form;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            form.Show();
        }
    }
