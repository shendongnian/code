    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow gvrow = GridView1.Rows[e.RowIndex];
    
        DropDownList DivisionsList = (DropDownList)gvrow.FindControl("DivisionsList"); 
        HiddenField hidden = (HiddenField)gvrow.FindControl("divisioncode");
        string division_code=hidden.value.ToString();
        TextBox txtEmployeeName = (TextBox)gvrow.FindControl("txtEmployeeName");
        TextBox txtJobTitle = (TextBox)gvrow.FindControl("txtJobTitle");
        TextBox txtBadgeNo = (TextBox)gvrow.FindControl("txtBadgeNo");
    
        CheckBox isActive = (CheckBox)gvrow.FindControl("isActive");
    
        //For getting the ID (primary key) of that row
        string username = GridView1.DataKeys[e.RowIndex].Value.ToString();
    
        string name = txtEmployeeName.Text;
        string jobTitle = txtJobTitle.Text;
        string badgeNo = txtBadgeNo.Text;
        string division = DivisionsList.SelectedValue.ToString();
    
        UpdateEmployeeInfo(username, name, jobTitle, badgeNo, division,division_code);
    }
