    void Page_load(object sender, EventArgs e)
    {
        CheckBox cb = new CheckBox();
        cb.Text = "text";
        cb.ID = "1";
        ph.Controls.Add(cb);
    }
    
    void Button_Click(object sender, EventArgs e)
    {
        CheckBox cb1 = (CheckBox)ph.FindControl("1");
        // Use checkbox here...
        Response.Write(cb1.Text);
    }
