    string query = "SELECT CAST(1 AS BIT) AS Process, TransID, Company, Period, EmpID, Employee FROM Trx"
    tblClaim = DB.sql.Select(query);
    gcxClaim.ExGridControl.DataSource = tblClaim;
    gcxClaim.ExGridView.OptionsBehavior.Editable = true;
    for (int i = 0; i < tblClaim.Columns.Count; i++)
    {
        gcxClaim.ExGridView.Columns[i].OptionsColumn.AllowEdit = false;
    }
    gcxClaim.ExGridView.Columns["Process"].OptionsColumn.AllowEdit = true;
