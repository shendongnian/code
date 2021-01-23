        string filePath = Server.MapPath("~/ReportFiles/CenterMemberAddressDifferentReport_" + Emp_Session._UserMasterId + ".xls");
            System.IO.File.Copy(Server.MapPath("~/Images/ExcelTemplate.xls"), filePath, true);
    
                System.Threading.Thread.Sleep(1000);
    
                string driver = "provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + filePath + "';Extended Properties=Excel 8.0;";
                System.Data.OleDb.OleDbConnection Con = new System.Data.OleDb.OleDbConnection(driver);
                System.Data.OleDb.OleDbCommand Com = Con.CreateCommand();
                System.Data.OleDb.OleDbDataAdapter reader = new OleDbDataAdapter();
                Con.Open();
                DataTable dtSheet = Con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string SQL = "";
    
                foreach (DataRow Row in dt1.Rows)
                {
                    string values = "";
                    for (int ik = 0; ik < dt1.Columns.Count; ik++)
                    {
                        if (values != "") values += ",";
                        values += "'" + Row[ik].ToString() + "'";
                    }
                    SQL = "INSERT INTO [Sheet1$] ([CENTER NAME],[CENTER ADDRESS],[MEMBER ID],[MEMBER NAME],[MEMBER ADDRESS],[MEMBER COUNT]) VALUES(" + values + ")";
                    Com.CommandText = SQL;
                    Com.ExecuteNonQuery();
                }
                Con.Close();
    
                System.Threading.Thread.Sleep(1000);
    
                System.IO.FileStream stream = System.IO.File.OpenRead(filePath);
                byte[] by = new byte[stream.Length];
                stream.Read(by, 0, by.Length);
                stream.Close();
                System.Threading.Thread.Sleep(1000);
                System.IO.File.Delete(filePath);
    
                Response.OutputStream.Write(by, 0, by.Length);
                Response.End();
