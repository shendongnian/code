     public static void LoadMainTable(ref DataTable mainGridTable, string comboSelectedValue)
            {
        
                //Loads entires into a data table
                //FormMonitor FormMonitor = new FormMonitor();
                string bankBox = FormMonitor.ComboBox1.SelectedItem;
                string theDate = FormMonitor.DateTimePicker.Value.ToString("yyyy-MM-dd");
        
        
        
                //Grabbed in the order they will be displayed
                cmd.CommandText = String.Format("W.I.P.");
                //Add variables for filters after figuring out how to do it
                reader = cmd.ExecuteReader();
        
        
                //reads data into dmainGridTable
                while (reader.Read())
                {
        
                    mainGridTable.Rows.Add(reader["column1"], reader["column2"], reader["column3"], reader["column4"].ToString(),
                                            reader["column5"].ToString(), reader["column6"]);
                    //FormMonitor.file_ProgressUpdated(); //non-static error again, fix
                    connect.Close();
                }
           
 }
