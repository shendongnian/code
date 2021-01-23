    string strWhere = string.Empty;
        string strOrderBy = string.Empty;
 
        if (!string.IsNullOrEmpty(txtAddress.Text))
            strWhere = "Address.StartsWith(\"" + txtAddress.Text + "\")";  
        if (!string.IsNullOrEmpty(txtEmpId.Text))
        {
            if(!string.IsNullOrEmpty(strWhere ))
                strWhere = " And ";
            strWhere = "Id = " + txtEmpId.Text;
        }
        if (!string.IsNullOrEmpty(txtDesc.Text))
        {
            if (!string.IsNullOrEmpty(strWhere))
                strWhere = " And ";
            strWhere = "Desc.StartsWith(\"" + txtDesc.Text + "\")";
        }
        if (!string.IsNullOrEmpty(txtName.Text))
        {
            if (!string.IsNullOrEmpty(strWhere))
                strWhere = " And ";
            strWhere = "Name.StartsWith(\"" + txtName.Text + "\")";
        }
 
        EmployeeDataContext edb = new EmployeeDataContext();
        var emp = edb.Employees.Where(strWhere);
        grdEmployee.DataSource = emp.ToList();
        grdEmployee.DataBind();
