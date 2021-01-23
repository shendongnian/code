    protected void Button1_Click(object sender, EventArgs e)
    {
        string id = TextBox1.Text;
        Session["id"] = id;
        GenerateDynamicControls(id);
    }
