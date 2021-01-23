    if (Directory.Exists(serverPath))
    {
        string FileExist = sp + "book1.xlsx"; ;
        string Exten = Path.GetExtension(FileExist);
        string g = "sheet1";              
        if (File.Exists(FileExist))
        {
            if (Exten == ".xlsx")
            {
                string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileExist + ";Extended Properties=Excel 12.0";
                OleDbConnection oledbConn = new OleDbConnection(connString);
                try
                {
                    // Open connection
                    oledbConn.Open();
                    string query = String.Format("select * from [{0}$]", g);
                    // Create OleDbCommand object and select data from worksheet Sheet1
                    OleDbCommand cmd = new OleDbCommand(query, oledbConn);
                    // Create new OleDbDataAdapter 
                    OleDbDataAdapter oleda = new OleDbDataAdapter();
                    oleda.SelectCommand = cmd;
                    // Create a DataSet which will hold the data extracted from the worksheet.
                    DataSet ds = new DataSet();
                    // Fill the DataSet from the data extracted from the worksheet.
                    oleda.Fill(ds, "sheetdt");                            
                    GridView1.DataSource = ds.Tables[0].DefaultView;
                    GridView1.DataBind();
                }
                catch (Exception ex)
                {
                    LblSuccess.Text = ex.Message;
                }
                finally
                {
                    // Close connection
                    oledbConn.Close();
                }
            }
        }
    }
