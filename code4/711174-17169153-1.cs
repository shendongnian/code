    SqlConnection thisConnection = new SqlConnection(@"Server=(local);Database=Sample_db;Trusted_Connection=Yes;");
                    thisConnection.Open();    
                    string Get_Data = "SELECT * FROM emp";  
                    SqlCommand cmd = thisConnection.CreateCommand();
                    cmd.CommandText = Get_Data;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);               
                    DataTable dt = new DataTable("emp");
                    sda.Fill(dt);
                   // Here:                
                   dataGrid1.DataContext = dt.DefaultView; 
