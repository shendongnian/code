    string sqlText = "UPDATE tbl_Results SET [Q1-Easy] = ? WHERE Username = ?";
    using(OleDbConnection ECon = new OleDbConnection(.....))
    using(OleDbCommand cmd = new OleDbCommand(sqlText, ECon))
    {
       ECon.Open();
       cmd.Parameters.Add("@Q1Value", OleDbType.Boolean).Value = true;
       cmd.Parameters.Add("@uname", OleDbType.VarChar).Value = txtUname.Text;
       cmd.ExecuteNonQuery();
    }
