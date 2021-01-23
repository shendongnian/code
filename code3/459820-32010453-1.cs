     Conn obcon = new Conn();
     SqlConnection ob = new SqlConnection(obcon.strCon);
     SqlDataAdapter da = new SqlDataAdapter();
     da.SelectCommand = new SqlCommand();
     da.SelectCommand.Connection = ob;
     SqlCommand ds = da.SelectCommand;
     ds.CommandText = "Select* from UserManagement";
     ds.CommandType = CommandType.Text;
     DataTable dt = new DataTable();
     da.Fill(dt);
     DataTable dtt = new DataTable();
     dtt.Columns.Add("FullName");
     dtt.Rows.Add();
     dtt.Rows[0]["FullName"] = "Select Name";
     for (int i = 0; i < dt.Rows.Count; i++)
     {
         dtt.Rows.Add();
         dtt.Rows[i + 1]["FullName"] = dt.Rows[i][0].ToString();
     }
     cmbFindUser.DataSource = dtt;
     cmbFindUser.DisplayMember = "FullName";
     cmbFindUser.ValueMember = "FullName";
    enter code here
