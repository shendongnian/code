    public partial class Form2 : Form
    {
        public Form2(ITextChange f)
        {
            InitializeComponent();
            f.SomeTextChanged += new EventHandler(f_SomeTextChanged);
        }
        void f_SomeTextChanged(object sender, EventArgs e)
        {
            textBox1.Text = sender.ToString();
        }
    }
