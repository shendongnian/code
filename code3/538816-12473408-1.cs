    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        DropDownList1.Visible = CheckBox1.Checked;
        TextBox1.Visible = !CheckBox1.Checked;
    }
