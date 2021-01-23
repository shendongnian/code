    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
        }
        private void f2button_Click(object sender, EventArgs e)
        {
            f1Words f1w = new f1Words();
            f1w.Words1();
        }
    }
    public class f2Words
    {
        public void Words2()
        {
            MessageBox.Show("Form 2 Method Calling Worked!");
        }
    }
