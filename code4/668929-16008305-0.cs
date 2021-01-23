    protected void Button2_Click(object sender, EventArgs e)
    {
        using (ResXResourceWriter resx = new ResXResourceWriter("Resources.resx"))
        {   resx.AddResource( "joth", "joth");
            resx.Save();
            resx.Close();
        }
    } 
