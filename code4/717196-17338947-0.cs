    public void ButtonAddNewTextbox_Click(object sender, EventArgs e) 
    {
       TextBox textbox = new TextBox();
       textbox.Location = new Point(); // specify position inside the constructor
    
       Controls.Add(textbox);
    }
