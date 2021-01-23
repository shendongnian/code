    namespace PunchOut
    {
        public partial class Form2 : Form
        {
             public String richText;
             public Form2(String rText)
             {    
                  InitializeComponent();
                  this.richTextBox1.Rtf = rText;
             }
           
            private void Form2_FormClosing(object sender, FormClosingEventArgs e)
            {
                richText = this.richTextBox1.Rtf;
            }
        }
    }
