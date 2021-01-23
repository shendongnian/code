    protected void Button1_Click(Object sender, EventArgs e)
    {
        Page.Validate();
        if(Page.IsValid)
        {
           // servervalidate should have been called
        }
    }
