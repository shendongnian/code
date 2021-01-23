     string connectString =
                    "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=d:\\testit.xlsx;Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1;\"";
                OleDbConnection conn = new OleDbConnection(connectString);
                OleDbDataAdapter da = new OleDbDataAdapter("Select * From [Sheet1$]", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                // Save your datatable records to DB as you prefer.
