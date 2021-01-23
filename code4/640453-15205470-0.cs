    protected void bindDepartments()
    {
        SqlConnection strcon1 = new SqlConnection(strcon);
        strcon1.Open();
        string ADDStr = "SELECT DepartmentId,DepartmentName FROM Departments ";
        SqlCommand ADDCmd = new SqlCommand(ADDStr, strcon1);
        DataTable table = new DataTable();
        SqlDataAdapter adapter = new SqlDataAdapter(ADDCmd);
        adapter.Fill(table);
        
        ddlDepartments.DataSource = table;
        ddlDepartments.DataValueField = "DepartmentId";
        ddlDepartments.DataTextField = "DepartmentName";
        ddlDepartments.DataBind();
    }
