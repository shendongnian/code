     try {
       lvItems.Columns.Clear() ;
       lvItems.Items.Clear();
       conn.Open();
       txtSql.Text ="select * from Employee";
       SqlCommand cmd = conn.CreateCommand();
       cmd.CommandText = txtSql.Text;
       SqlDataReader dr = cmd.ExecuteReader();
       for (int i = 0; i< dr.FieldCount; i++) {
         ColumnHeader ch = new ColumnHeader();
         ch.Text=dr.GetName(i);
         lvItems.Columns.Add(ch);
       }
       ListViewItem itmX; 
       while (dr.Read()) {
         itmX=new ListViewItem(); 
         itmX.Text= dr.GetValue(0).ToString();
         for (int i=1 ; i< dr.FieldCount; i++) {
            itmX.SubItems.Add(dr.GetValue(i).ToString());
         }
         lvwResult.Items.Add(itmX);
       }
       dr.Close();
    } catch ( System.Data.SqlClient.SqlException  ex) {
       Console.WriteLine("There was an error in executing the SQL." +
               "\nError Message:" + ex.Message, "SQL");
    } finally {
       conn.Close();
    }
