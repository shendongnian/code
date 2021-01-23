    Response.Clear();
    Response.AddHeader("content-disposition", string.Format("attachment;filename=file_{0}.csv", batchId));
    Response.ContentType = "text/csv";
    using (SqlDataReader rdr= GetDataForCSV())
    {
        int i = 0;
        while (rdr.Read())
        {
           Response.Write(CSVFromIDataRecord(rdr));
           Response.Write("\n");
           if (i % 50 == 0)
           {
               //flush the output stream every now and then
               Response.Flush();
           }
        }
        rdr.Close();
    }
    Response.End();
