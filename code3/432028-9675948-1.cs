    public void Textbox1_TextChanged(object sender, EventArgs e)
    {
       if(handler1Running) return; //the second time through we exit immediately
       handler1Running = true;
       ...
       TextBox2.Text = "Something"; //the other event handler is invoked immediately
       handler1Running = false;
    }
    
    public void Textbox2_TextChanged(object sender, EventArgs e)
    {
       if(handler2Running) return; //the second time through we exit immediately
       handler2Running = true;
       ...
       TextBox1.Text = "Something Else"; //the other event handler is invoked immediately
       handler2Running = false;
    }
