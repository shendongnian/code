    public class Form2
    {
        public int TabSelectedIndex 
        { 
           set { tabControl.TabIndex = value; }
        }
    }
    
    public class Form1
    {
        private Form2 _form2 = new Form2();
    
        private void Button1_Click(object sender, EventArgs e)
        {
            _form2.TabSelectedIndex = 1;
        }
    }
