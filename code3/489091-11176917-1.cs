    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack){
            DataTable dt = new DataTable();
            Duty dy = new Duty();
            dt = dy.getdutyid(Convert.ToInt32(dropcontractid.SelectedValue));
            // Use FindControl() to access duty dropdown if editor shows error on duty
            duty.DataSource = dt;
            duty.DataTextField = "dutyid";
            duty.DataValueField = "dutyid";
            duty.DataBind();
            TextBox1.Text = duty.SelectedItem.Value;
        }
    }
    protected void duty_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        TextBox1.Text = ddl.SelectedItem.Value;
    }
