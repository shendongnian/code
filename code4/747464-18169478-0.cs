    protected void Button1_Click(object sender, EventArgs e)
    {
        string Name = "";
        string Type = "";
        string Id = "";
        foreach (Control ctr in form1.Controls)
        {
            Name = ctr.GetType().Name;
            Type = ctr.GetType().ToString(); ;
            Id = ctr.ID; // If its server control
        }
    }
