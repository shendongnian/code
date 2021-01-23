    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        public String SomeProperty { get; set; }
    
        private void OpenFormButton_Click(object sender, EventArgs e)
        {
            var secondForm = new Form2()
            {
                GetSomeProperty = () => { return SomeProperty ;};
            };
            secondForm.Show();
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
            SomeProperty = "HELLO WORLD";
        }
    }
    
    
    
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
    
        public Func<string> GetSomeProperty
        {
            get;
            set;
        }
    
        private void Form2_Load(object sender, EventArgs e)
        {
            MessageBox.Show(GetSomeProperty.Invoke());
        }
    }
