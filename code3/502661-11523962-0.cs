    DbProviderFactory df = DbProviderFactories.GetFactory(dbconnect.dbprovider);             
                using(DbConnection con = df.CreateConnection())
                {
                    con.ConnectionString = "dbconnect.sqlstr";              
                    DbCommand cmd = df.CreateCommand(); 
                    cmd.CommandText = "update customer set" + " name='@name'," + "address='@address'," + "phone='@phone' " + "where code='@code';";
                    cmd.Connection = con; 
                   
                    DbParameter param1 = df.CreateParameter(); 
                    param1.ParameterName = "@name"; 
                    param1.Value = txtname.Text;
    
                    DbParameter param2 = df.CreateParameter(); 
                    param2.ParameterName = "@address"; 
                    param2.Value = txtadd.Text; 
    
                    DbParameter param3 = df.CreateParameter(); 
                    param3.ParameterName = "@phone"; 
                    param3.Value = txtphone.Text; 
     
                    DbParameter param4 = df.CreateParameter(); 
                    param4.ParameterName = "@code"; 
                    param4.Value = txtcode.Text;
                    
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
