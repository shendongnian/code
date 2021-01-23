    private bool StrangeSqlCeCode(DataSet dset) {
      const string ACCOUNT_ID = "AccountID";
      const string DEPARTMENTS = "Departments";
      const string NAME = "Name";
      const string SQL_TEXT = "INSERT INTO departments (account_id, name) VALUES (@account_id, @name)";
      bool ret = false;
      //bool First = false; (we don't need this anymore, because we initialize the SqlCeCommand correctly up front)
      using (SqlCeCommand cmd = new SqlCeCommand(SQL_TEXT)) {
        // Be sure to set this to the data type of the database and size field
        cmd.Parameters.Add("@account_id", SqlDbType.NVarChar, 100);
        cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100);
        if (-1 < dset.Tables.IndexOf(DEPARTMENTS)) {
          DataTable tab = dset.Tables[DEPARTMENTS];
          foreach (DataRow row in tab.Rows) {
            // Check this much earlier. No need in doing all the rest if a Cancel has been requested
            if (!frmCentral.CancelFetchInvDataInProgress) {
              Department Dept = new Department();
              if (!ret)
                ret = true;
              // Wow! Long way about getting the data below:
              //foreach (DataColumn column in tab.Columns) {
              //  if (column.ColumnName == "AccountID") {
              //    Dept.AccountID = (string)row[column];
              //  } else if (column.ColumnName == "Name") {
              //    Dept.AccountName = !row.IsNull(column) ? row[column].ToString() : String.Empty;
              //  }
              //}
              if (-1 < tab.Columns.IndexOf(ACCOUNT_ID)) {
                Dept.AccountID = row[ACCOUNT_ID].ToString();
              }
              if (-1 < tab.Columns.IndexOf(NAME)) {
                Dept.AccountName = row[NAME].ToString();
              }
              List.List.Add(Dept);
              // This statement below is logically the same as cmd.CommandText, so just don't use it
              //string dSQL = "INSERT INTO departments ( account_id, name) VALUES ('" + Dept.AccountID + "','" + Dept.AccountName + "')";
              cmd.Parameters["@account_id"].Value = Dept.AccountID;
              cmd.Parameters["@name"].Value = Dept.AccountName;
              cmd.Prepare(); // I really don't ever use this. Is it necessary? Perhaps.
              // This whole routine below is already in a Try/Catch, so this one isn't necessary
              //try {
              dbconn.DBCommand(cmd, true);
              //} catch {
              //}
            } else {
              ret = false;
              return ret;
            }
          }
        }
      }
      return ret;
    }
