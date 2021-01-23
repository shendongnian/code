            try
            {
           Dataset myDataSet=new Dataset();
            string connection = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\Database3.accdb";
            OleDbCommand cmd = new OleDbCommand("Select * from score", conn);
            OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(cmd );
 
            connection .Open();
            myDataAdapter.Fill(myDataSet,"TableName");
 
            }
            catch (Exception ex)
            {
                  Console.WriteLine("Error: Failed to retrieve the required data from the DataBase.\n{0}", ex.Message);
                  return;
            }
            finally
            {
                  connection .Close();
            }
