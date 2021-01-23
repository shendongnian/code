    public partial class Form4 : Form
    {
        private string _valueFromOtherForm;
        public Form4()
        {
            InitializeComponent();
        }
        public Form4(string valuePassed)
        {
            InitializeComponent();
            _valueFromOtherForm = valuePassed;
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            label1.Text = _valueFromOtherForm;
        }
    }
}
