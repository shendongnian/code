    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            TextBox textBox = new TextBox();
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                var shared = new SharedClass();
                textBox.Text = shared.DoLogic(10).ToString();
            }
        }
    }
