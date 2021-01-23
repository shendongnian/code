     public partial class Form1 : Form
        {
            public string rtbTypedText = "";
            public Form1()
            {
                InitializeComponent();
            }
     
    
          
          private void richTextBox1_MouseHover(object sender, EventArgs e)
                {
                    int result =0;
        
                    bool typeStatus = int.TryParse(rtbTypedText, out result);
                    if (typeStatus == true)
                        toolTip1.Show("It is a Number", richTextBox1);
                    else
                        toolTip1.Show("It is an Alphabet", richTextBox1);
        
                }
        
                private void richTextBox1_TextChanged(object sender, EventArgs e)
                {
                    string s = richTextBox1.Text;
        
                    string text = "";
                    string[] sp = s.Split(' ');
        
                    if (sp.Length == 0)
                        rtbTypedText = s;
                    else
                        rtbTypedText = sp[sp.Length - 1];
        
                    
        
                   
                }
    }
