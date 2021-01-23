    namespace PunchOut
    {
        public partial class Form2 : Form
        {
             public String richText;
             public Form2(String rText)
             {    
                  InitializeComponent();
                  this.textBox1.Rtf = rText;
             }
           
            private void Form2_FormClosing(object sender, FormClosingEventArgs e)
            {
                richText = this.textBox1.Rtf;
            }
        }
    }
