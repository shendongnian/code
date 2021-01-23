    public partial class TestForm : Form
    {
        MyLabel newLable;
        public TestForm()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            newLable = new MyLabel();
            newLable.Height = 30;
            newLable.Width = 40;
            newLable.Text = "hello";
            this.Controls.Add(newLable);
        }       
    }
