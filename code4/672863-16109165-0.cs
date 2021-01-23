    string filename = @"C:\Book1.xlsm";
            string connectionString = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=YES\";", filename);
            string query = String.Format("SELECT * from [{0}$]", "Sheet1");
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connectionString);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            DataTable YourTable = dataSet.Tables[0];
