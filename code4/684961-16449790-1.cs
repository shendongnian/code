    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.divpanel.Visible = false; 
        }
        
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        this.DropDownList1.Items.Add(this.TextBox1.Text.ToString());
        DropDownList1.DataBind();
    }
    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        this.divpanel.Visible = true;
        this.divpanel1.Visible = false;
    }
