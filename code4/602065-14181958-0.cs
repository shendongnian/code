    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public String SomeProperty { get; set; }
        //Event of a normal button with name 'OpenFormButton'
        private void OpenFormButton_Click(object sender, EventArgs e)
        {
            var secondForm = new Form2
            {
                Owner = this
            };
            secondForm.Show();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            SomeProperty = "HELLO WORLD";
        }
    }
