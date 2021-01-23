    protected void Page_Load(object sender, EventArgs e)
    {
        CheckBox cb = new CheckBox();
        cb.Text = "text";
        cb.ID = "1";
        frmDynamicControl.Controls.Add(cb);
    }
    
    protected void btnGetCheckBoxValue_Click(object sender, EventArgs e)
    {
        CheckBox cb1 = (CheckBox)Page.FindControl("1");
        // Use checkbox here...
        Response.Write(cb1.Text + ": " + cb1.Checked.ToString());
    }
