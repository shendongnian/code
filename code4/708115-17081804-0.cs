    protected void ButtonClick(object sender, EventArgs e)
    {
        string name = NameTextBox.Text;
        if(!String.IsNullOrEmpty(name))
        {
            Response.Write(name);
        }
    }
