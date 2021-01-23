                  string where = "";
                   string query = "SELECT * FROM [FNF Taxes] WHERE ControlNumber = {0};";
                   for (int i = 0; i < UserClassDict[UserName].ControlNumber.Count; i++)
                   {
                       if(i == UserClassDict[UserName].ControlNumber.Count -1 )
                          where+=UserClassDict[UserName].ControlNumber[i] ;
                       else
                           where += UserClassDict[UserName].ControlNumber[i] + ",";
                       
                   }
                   adapter.SelectCommand = new OleDbCommand(string.Format( query,where), conn);
                   DataSet dataset = new DataSet();
                   adapter.Fill(dataset);
                   if (dataset.Tables[0].Rows.Count > 0)
                   {
                       if (dt == null)
                           dt = dataset.Tables[0];
                   }
