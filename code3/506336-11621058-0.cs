    for(int i = 0; i <100; i++)
    {
       TextBox t = new TextBox(){ Id = "txt_" + i, Value = "txt_" + i};
       t.OnTextChanged += new System.EventHandler(this.textBox_ontextchanged);
      Page.Controls.Add(t);
    
    }
    
    //and for event on OnTextChanged
    private void textBox_ontextchanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
    
            if (textBox != null)
            {
    ////
            }
        }
