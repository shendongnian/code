    public partial class Form2 : Form
    {
        public SimpleForm SourceForm { get; set; }
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            //i'am changing Title property on first form...
            SourceForm.Text = "Changed title on SourceForm";
        }
    }
