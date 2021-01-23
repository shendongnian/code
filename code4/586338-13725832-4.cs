    public partial class Form1 : Form
    {
        OtherForm otherForm;
        public Form1()
        {
            InitializeComponent();
            otherForm = new OtherForm();
            otherForm.Show(this);
        }
    }
    //...
    public partial class OtherForm : Form
    {
        public OtherForm()
        {
            InitializeComponent();
        }
        string SomeMethod()
        {
            var parent = (Form1)this.Owner;
            return parent.textBox1.Text;
        }
        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = SomeMethod();
        }
    }
