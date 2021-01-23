    private static void UploadExcelToDB(string p)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnString))
                {
                    conn.Open();
                    if (conn.State == ConnectionState.Open)
                    {
                        Log("Opened connection to DB");
                    }
                    SqlBulkCopy sbk = new SqlBulkCopy(conn);
                    sbk.BulkCopyTimeout = 600;
                    sbk.DestinationTableName = DbTableName;
                    DataTable excelDT = new DataTable();
                    OleDbConnection excelConn = new OleDbConnection(ExcelConnString.Replace("xFILEx",p));
                    excelConn.Open();
                    if (excelConn.State == ConnectionState.Open)
                    {
                        Log("Opened connection to Excel");
                    }
                    OleDbCommand cmdExcel = new OleDbCommand();
                    OleDbDataAdapter oda = new OleDbDataAdapter();
                    cmdExcel.CommandText = "SELECT * FROM ["+ExcelTableName+"]";
                    cmdExcel.Connection = excelConn;
                    oda.SelectCommand = cmdExcel;
                    oda.Fill(excelDT);
                    if (excelDT != null)
                    {
                        Log("Fetched records to local Data Table");
                    }
                    excelConn.Close();
                    SqlCommand sqlCmd = new SqlCommand("TRUNCATE TABLE ICN_NUGGET_REPORT_RAW",conn);
                    sqlCmd.CommandType = CommandType.Text;
                    Log("Trying to clear current data in table");
                    int i = sqlCmd.ExecuteNonQuery();
                    Log("Table flushed");
                    Log("Trying write new data to server");
                    sbk.WriteToServer(excelDT);
                    Log("Written to server");
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Log("ERROR: " + ex.Message);
                SendErrorReportMail();
            }
            finally
            {
                #if (DEBUG)
                {
                }
                #else
                {
                string archive_file = ArchiveDir+"\\" + DateTime.Now.ToString("yyyyMMdd-Hmmss") + ".xlsx";
                File.Move(p, archive_file);
                Log("Moved processed file to archive dir");
                Log("Starting archive process...");
                }
                #endif
            }
        }
