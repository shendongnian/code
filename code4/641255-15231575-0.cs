    protected void Page_Init(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            rad_ddl_inner_emp_name.DataSource = Utilities.GetAllEmployees();
            rad_ddl_inner_emp_name.DataTextField = "name";
            rad_ddl_inner_emp_name.DataValueField = "emp_num";
            rad_ddl_inner_emp_name.DataBind();
        }
    }
    protected void txt_inner_emp_num_TextChanged(object sender, EventArgs e)
    {
        string value = txt_inner_emp_num.Text;
        if(!string.IsNullOrWhiteSpace(value))
        {
            value = value.Trim();
            if (rad_ddl_inner_emp_name.Items
                .FindItemByValue(txt_inner_emp_num.Text.Trim()) != null)
                rad_ddl_inner_emp_name.SelectedValue = value;
        }
    }
