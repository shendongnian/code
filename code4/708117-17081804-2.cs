    protected void ButtonClick(object sender, EventArgs e)
    {
        string name = Request.Form["fname"];
        //Or with a TextBox
        string name = fnameTextBox.Text;
        if(!String.IsNullOrEmpty(name))
        {
            Response.Write(name);
        }
    }
