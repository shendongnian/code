    private void button1_Click(object sender, System.EventArgs e) 
    { 
       mf= new MessageFilter();
    Application.AddMessageFilter(mf); 
    }
 
    private void button2_Click(object sender, System.EventArgs e) 
    { 
    Application.RemoveMessageFilter(mf); 
    }
`
 
