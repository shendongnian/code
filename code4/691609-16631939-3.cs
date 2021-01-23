    public partial class Form2 : Form
    {
        private readonly Form1 _form1;
        
        public Form2(Form1 form1)
        {
            _form1 = form1;
            InitializeComponent();
        }
        private void btnEnabler_Click(object sender, EventArgs e)
        {
            // access the exposed property here <-- in this case disable it
            _form1.BtnShowForm2.Enabled = false;
        }
    }
