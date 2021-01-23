    public static DataTable CsvFileToDatatable(string path, bool IsFirstRowHeader)//here    Path is root of file and IsFirstRowHeader is header is there or not
        {
            string header = "Yes"; //"No" if 1st row is not header cols
            string query = string.Empty;
            DataTable dataTable = null;
            string filePath = string.Empty;
            string fileName = string.Empty;
            try
            {
                //csv file directory
                filePath = Path.GetDirectoryName(ConfigurationManager.AppSettings["QuantumOutputFilesLocation"]);
                //csv file name
                fileName = Path.GetFileName(ConfigurationManager.AppSettings["CSVFilename"]);
                query = @"SELECT * FROM [" + fileName + "]";
                if (IsFirstRowHeader) header = "Yes";
                using (OleDbConnection connection = new OleDbConnection((@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties=\"Text;HDR=" + header + "\"")))               
                {
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                        {                                                     
                            dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            //create connection to Access DB
                            OleDbConnection DBconn = new OleDbConnection(ConfigurationManager.ConnectionStrings["Seagoe_QuantumConnectionString"].ConnectionString);
                            OleDbCommand cmd = new OleDbCommand();
                            //set cmd settings
                            cmd.Connection = DBconn;
                            cmd.CommandType = CommandType.Text;
                            //open DB connection
                            DBconn.Open();
                            //read each row in the Datatable and insert that record into the DB
                            for (int i = 0; i < dataTable.Rows.Count; i++)
                            {
                                cmd.CommandText = "INSERT INTO tblQuantum (DateEntered, Series, SerialNumber, YearCode, ModelNumber, BatchNumber, DeviceType, RatedPower, EnergyStorageCapacity," +
                                                                          "MaxEnergyStorageCapacity, User_IF_FWRevNo, Charge_Controller_FWRevNo, RF_Module_FWRevNo, SSEGroupNumber, TariffSetting)" +
                                                 " VALUES ('" + dataTable.Rows[i].ItemArray.GetValue(0) + "','" + dataTable.Rows[i].ItemArray.GetValue(1) + "','" + dataTable.Rows[i].ItemArray.GetValue(2) +
                                                 "','" + dataTable.Rows[i].ItemArray.GetValue(3) + "','" + dataTable.Rows[i].ItemArray.GetValue(4) + "','" + dataTable.Rows[i].ItemArray.GetValue(5) +
                                                 "','" + dataTable.Rows[i].ItemArray.GetValue(6) + "','" + dataTable.Rows[i].ItemArray.GetValue(7) + "','" + dataTable.Rows[i].ItemArray.GetValue(8) +
                                                 "','" + dataTable.Rows[i].ItemArray.GetValue(9) + "','" + dataTable.Rows[i].ItemArray.GetValue(10) + "','" + dataTable.Rows[i].ItemArray.GetValue(11) +
                                                 "','" + dataTable.Rows[i].ItemArray.GetValue(12) + "','" + dataTable.Rows[i].ItemArray.GetValue(13) + "','" + dataTable.Rows[i].ItemArray.GetValue(14) + "')";
                                cmd.ExecuteNonQuery();
                            }
                            //close DB.connection
                            DBconn.Close();
                        }
                    }
                }
            }
            finally
            {
            }
            return dataTable;
        }
