    for(int i = 0; i <100; i++)
    {
       TextBox t = new TextBox(){ Id = "txt_" + i, Value = "txt_" + i};
       t.TextChanged += new System.EventHandler(this.textBox_Textchanged);
      Page.Controls.Add(t);
    
    }
    
    //and for event on TextChanged
    private void textBox_Textchanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
    
            if (textBox != null)
            {
    ////
            }
        }
