    if (!this.IsPostBack)
    {
           SqlDataSource empDB = (SqlDataSource)Page.Master.FindControl("EmployeeData");
            DataView dv = (DataView)empDB.Select(DataSourceSelectArguments.Empty);
    
            foreach (DataRowView drv in dv)
            {
                employeeList.Add(new Employee(int.Parse(drv["EMP_ID"].ToString()), drv     ["FULL_NAME"].ToString()));
            }
    
            managerTest();
    
            managerDropDownList.DataSource = managerList;
            managerDropDownList.DataTextField = "fullName";
            managerDropDownList.DataValueField = "emp_Id";
            managerDropDownList.DataBind();
    }
