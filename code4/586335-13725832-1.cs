    public partial class Form1 : Form
    {
        OtherForm otherForm;
        public Form1()
        {
            InitializeComponent();
            otherForm = new OtherForm();
            otherForm.Show(this);
            textBox1.TextChanged += textBox1_TextChanged;
        }
        void textBox1_TextChanged(object sender, EventArgs e)
        {
            otherForm.textBox1.Text = textBox1.Text;
        }
    }
