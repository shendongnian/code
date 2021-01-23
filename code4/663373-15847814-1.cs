     public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                _Form1 = this;
            }
            public static  Form1 _Form1;
            public void update(string message)
            {
                richTextBox1.AppendText("mess: " + message);
                MessageBox.Show(message);
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                Class1 sample = new Class1();
            }
        }
