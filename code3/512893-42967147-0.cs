    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
        }
        
        private void f1button_Click(object sender, EventArgs e)
        {
            f2Words f2w = new f2Words();
            f2w.Words2();
        }
    }
    public class f1Words
    {
        public void Words1()
        {
            MessageBox.Show("Form 1 Method Calling Worked!");
        }
    }
