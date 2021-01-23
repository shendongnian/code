            DataSet dataset = Read_File_Into_Dataset("C:\\TEMP\\", "input.txt");
            DataGrid dg = new DataGrid();
            dg.DataSource = dataset;
            dg.DataBind();
            this.Controls.Add(dg);
            public DataSet Read_File_Into_Dataset(string fullpath, string file)
            {
            string sql = "SELECT * FROM `" + file + "`"; // Read all the data
            OleDbConnection connection = new OleDbConnection // Connection
              ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fullpath + ";"
               + "Extended Properties=\"text;HDR=YES;FMT=Delimited\"");
            OleDbDataAdapter ole = new OleDbDataAdapter(sql, connection); // Load the data into the adapter
            DataSet dataset = new DataSet(); // To hold the data
            ole.Fill(dataset); // Fill the dataset with the data from the adapter
            connection.Close(); // Close the connection
            connection.Dispose(); // Dispose of the connection
            ole.Dispose(); // Get rid of the adapter
            return dataset;
            }
