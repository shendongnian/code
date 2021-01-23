    namespace PunchOut
    {
        public partial class Form2 : Form
        {
           PunchOut punchOut;
           public Form2(Form PUNCHOUT)
           {
                punchOut = PUNCHOUT;
                InitializeComponent();
           }
    
            public void richTextBox1_TextChanged(object sender, EventArgs e)
            {
                punchOut.richTextBox1.Text = PunchOut.richTextBox1.Text;
            }
        }
    }
