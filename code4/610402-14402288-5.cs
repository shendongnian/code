    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            var test = new Test();
            var label = new Label();
            label.Text = "test";
            test.Controls.Add(label);
            Controls.Add(test);
        }
    }
