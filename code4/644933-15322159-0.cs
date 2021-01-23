    private DataTable YourData()  
    {  
        string conString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|db_admin.mdb; Jet OLEDB:Database Password=admin";  
        DataSet ds = new DataSet();  
        using (SqlConnection conn = new SqlConnection(conString))  
        {  
            try  
            {  
                conn.Open();  
                SqlCommand command = new SqlCommand("select * from tbl_admin", conn);  
                command.CommandType = CommandType.Text;  
                SqlDataAdapter adapter = new SqlDataAdapter(command);  
                adapter.Fill(ds);  
                if (ds.Tables[0].Rows.Count > 0)  
                {  
                    // do somethign here  
                }  
            }
            catch (Exception)  
            {
                /*Handle error*/  
            }  
        }  
        return ds.Tables[0];  
    }  
