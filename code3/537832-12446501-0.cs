    string connString = "server=localhost;User Id=root;database=collegelist;";
    MySqlConnection conn = new MySqlConnection(connString);
    string selectSQL = "SELECT * FROM collegeemployee";
    conn.Open();
    MySqlDataAdapter da = new MySqlDataAdapter(selectSQL, conn);
    MySqlCommandBuilder builder = new MySqlCommandBuilder(da);
        BindingSource BindingSourceToUpdate = (BindingSource)dgView2.DataSource; // because direct casting to data table was failing in VS2o1o
    
                     try
                    {
        dgView2.Rows.RemoveAt(dgView2.CurrentRow.Index);
                        
                        da.Update((DataTable)BindingSourceToUpdate.DataSource);
                    }
                    catch(exception)
                     {
                     }
    conn.close();
