    namespace WindowsFormsApplication2
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
    
                button1.Click += button1_Click;
            }
            private void button1_Click(object sender, EventArgs e)
            {
                textBox2.Text = "Hello ";
                System.Windows.Forms.MessageBox.Show("hello");
            }
        }
    }
