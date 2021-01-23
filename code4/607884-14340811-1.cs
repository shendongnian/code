    protected void Button1_Click(object sender, EventArgs e)
    {
        Type cstype = this.GetType();
        Label message1 = (Label)(FindControl("lblMessage1"));
        message1.Text = "adam";
        UpdatePanel1.Update();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Type cstype = this.GetType();
        Label message2 = (Label)(FindControl("lblMessage2"));
        message2.Text = "adam2";
        UpdatePanel1.Update();
    }
