    public void Button1_Click(object sender, ClickEventArgs e)
    {    
       string text = TextBox1.Text;
        // spliting text on the basis on newline.
        string[] myArray = text.Split(new char[] { '\n' });
        
        foreach (string s in myArray)
        {
           //Line by line copy
           TextBox2.Text += s;
        }
    }
