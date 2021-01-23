    public void RetrieveData(Stream outputStream)
    {
        string connString = ConfigurationManager.ConnectionStrings["Platform"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connString))
        using (GZipStream compressStream = new GZipStream(outputStream, CompressionMode.Compress))
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand("SELECT * FROM expenses.CST_COSTHEADER", conn);
            adapter.Fill(dataset);   
            dataSet.WriteXml(compressStream);             
        }
    }
