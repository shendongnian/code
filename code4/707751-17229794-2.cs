        private void Connection() 
    {   
              //connect to the database and table
              //selecting all the columns
              //adding the name column alone to the combobox 
    
             try 
             {
                 string connstr = @"Data Source=.\TestImage.sdf;Persist Security Info=False;"; 
    
                 SqlCeConnection conn = new SqlCeConnection(connstr);  
                 conn.Open();
    			 SqlCeCommand selectCmd = conn.CreateCommand();
    			 selectCmd.CommandText = "SELECT * FROM test_table";
                 SqlCeDataAdapter adp = new SqlCeDataAdapter(selectCmd);              
                 dset = new DataSet("dset");
                 adp.Fill(dset);   
                 DataTable dtable;     
                 dtable = dset.Tables[0];
    			 if(comboBox1.Items.Count>0)
    			 {
    				comboBox1.Items.Clear(); 
    		     }
                 foreach (DataRow drow in dtable.Rows)
                 { 
    				comboBox1.Items.Add(drow[0].ToString()); 				
                 } 
    			 comboBox1.SelectedIndex = 0; 
             }
             catch (Exception ex)
             {
              MessageBox.Show(ex.Message);    
             }   
    		 finally
    		 {
    			conn.Open();
    		 }
    }
