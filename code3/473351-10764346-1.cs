    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        this.xx.Visible = CheckBox1.Checked;
    }
    
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.Label2.Text = this.DropDownList1.Text;
    }
