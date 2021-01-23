      private void ImportCSV(string filePath = @"E:\nucc_taxonomy_140.csv", string tableName = "TempTaxonomyCodes")
        {
            string tempPath = System.IO.Path.GetDirectoryName(filePath);
            string strConn = @"Driver={Microsoft Text Driver (*.txt; *.csv)};Dbq=" + tempPath + @"\;Extensions=asc,csv,tab,txt";
            OdbcConnection conn = new OdbcConnection(strConn);
            OdbcDataAdapter da = new OdbcDataAdapter("Select * from " + System.IO.Path.GetFileName(filePath), conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(ConfigurationSettings.AppSettings["dbConnectionString"]))
            {
                bulkCopy.DestinationTableName = tableName;
                bulkCopy.BatchSize = 50;
                bulkCopy.WriteToServer(dt);
            }
           
        }
