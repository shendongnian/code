     //Perform your validation
     // return true/false 
}
            DataTable dt7 = new DataTable();
            dt7.Load(dr);
            DataRow[] ExcelRows = new DataRow[dt7.Rows.Count];
            // Bulk Copy to SQL Server
            
            // Perform your validation here. If not validated then skip with some message.
            if(!Validate(dt7))
            {
                 //Show Message
                 return;
            }            
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(sqlConnectionString))
            {
                bulkCopy.DestinationTableName = "ExcelTable";
                dt7.Rows.CopyTo(ExcelRows, 0);
                for (int i = 0; i < ExcelRows.Length; i++)
                {
                    if (ExcelRows[i]["data"] == DBNull.Value)
                    {
                        // Include any actions to perform if there is no date
                        //ExcelRows[i]["data"] = Convert.ToString(0);
                    }
                    else
                    {
                        DateTime oldDate = Convert.ToDateTime(ExcelRows[i]["data"]).Date;
                        DateTime newDate = Convert.ToDateTime(oldDate).Date;
                        ExcelRows[i]["data"] = newDate.ToString("yyyy/MM/dd");
                    }
                }
                bulkCopy.WriteToServer(ExcelRows);
