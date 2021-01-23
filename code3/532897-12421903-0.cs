    private void button1_Click(object sender, EventArgs e)
        {
 
            Stopwatch swra = new Stopwatch();
            swra.Start();
            string NewconnectionString = "myCoonectionString";
            StreamWriter CsvfileWriter = new StreamWriter(@"D:\testfile.csv");
            string sqlselectQuery = "select * from Mytable";
            SqlCommand sqlcmd = new SqlCommand();
 
            SqlConnection spContentConn = new SqlConnection(NewconnectionString);
            sqlcmd.Connection = spContentConn;
            sqlcmd.CommandTimeout = 0;
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.CommandText = sqlselectQuery;
            spContentConn.Open();
            using (spContentConn)
            {
                using (SqlDataReader sdr = sqlcmd.ExecuteReader())
                using (CsvfileWriter)
                {
                    //For getting the Table Headers
                    DataTable Tablecolumns = new DataTable();
 
                    for (int i = 0; i < sdr.FieldCount; i++)
                    {
                        Tablecolumns.Columns.Add(sdr.GetName(i));
                    }
                    CsvfileWriter.WriteLine(string.Join(",", Tablecolumns.Columns.Cast<datacolumn>().Select(csvfile => csvfile.ColumnName)));
                    //For table headers
                    while (sdr.Read())
                    //based on your columns
                        YourWriter.WriteLine(sdr[0].ToString() + "," + sdr[1].ToString() + "," + sdr[2].ToString() + "," + sdr[3].ToString() + "," + sdr[4].ToString() + "," + sdr[5].ToString() + "," + sdr[6].ToString() + "," + sdr[7].ToString() + "," + sdr[8].ToString() + "," + sdr[9].ToString() + "," + sdr[10].ToString() + "," + sdr[11].ToString() + ",");
                       
                }
            }
           swra.Stop();
    Console.WriteLine(swra.ElapsedMilliseconds);
    }
 
