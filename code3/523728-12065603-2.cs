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
                richTextBox1.Text = punchOut.richTextBox1.Text;
            }
        }
    }
