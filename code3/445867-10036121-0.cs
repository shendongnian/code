    try
    {
    
           using(OleDbConnection excelConnection = new OleDbConnection(String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"", filename)))
           {
            excelConnection .Open();     
              using(OleDbCommand command = new OleDbCommand("SELECT columbia_uni, name, score, submitdate, test from [sheet1$]", excelconn))
              {     
                     command.CommandType = CommandType.Text;
                     using(IDataReader reader = command.ExecuteReader())
                     {
                        while(reader.Read())
                        {
                          //Do something
                        }
                     }    
              }
           }
    
    
    }
    catch(Exception e)
    {
        MessageBox.Show("The File " + filename + " cann't be read.  It is either in use by a different user \n or it doen't contain the correct columns.  Please ensure that column A1 is Columbia_UNI B1 is Name C1 is Score D1 is Submitdate and E1 is Test.\r\n The actual exception message is: " + e.Message);
    }
