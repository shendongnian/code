    private void GetEmployee()
    {
        var db = new knowitCVdbEntities();
        var employee = (from p in db.EMPLOYEES
                        where
                            p.firstname.Contains(TextBoxSearch.Text) ||
                            p.lastname.Contains(TextBoxSearch.Text) ||
                            p.position.Contains(TextBoxSearch.Text)
                        select p).ToList();
        
        _dt.Clear();
        foreach (var vEmp in employee)
        {
            if (vEmp != null)
            {
                HiddenFieldID.Value = vEmp.employee_id.ToString();
                        if (Session["DataTableSearch"] != null)
                        {
                            _dt = (DataTable)Session["DataTableSearch"];
                        }
                        else
                        {
                            _dt.Columns.Add("Firstname");
                            _dt.Columns.Add("employeeId");
                        }
                        //_dt.Rows.Clear();
                        DataRow dr = _dt.NewRow();
                        dr["Firstname"] = vEmp.firstname+" "+vEmp.lastname;
                         dr["employeeId"] = vEmp.employee_id;
                        _dt.Rows.Add(dr);
                        Session["DataTableSearch"] = _dt;
                        GridViewDisplayName.DataSource = _dt;
                        GridViewDisplayName.DataBind();
                    }
            }
    }
