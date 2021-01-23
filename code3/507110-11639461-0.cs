    private DataTable tblEmployees;
    private void buttonFilter_Click(object sender, System.EventArgs e)
    {
       if(tblEmployees != null)
       {
           DataTable filtered = tblEmployees.AsEnumerable()
                                .Where(r => r.Fields<String>("EmployeeKey") == TextBox12.Text)
                                .CopyToDataTable();
           // do something with it ...
       }
    }
