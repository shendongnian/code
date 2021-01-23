    public void ToCSV(DataTable dt, Stream outStream)
    { 
        StreamWriter writer = new StreamWriter(outStream); 
        try 
        { 
            bool first = true;
            foreach (DataColumn col in dt.Columns) 
            {
                if (first)
                    first = false;
                else
                    writer.Write(",");
                
                writer.Write(col.ColumnName); 
            } 
            writer.WriteLine(); 
            foreach (DataRow row in dt.Rows) 
            { 
                for (int i = 0; i < dt.Columns.Count; i++) 
                { 
                    writer.Write("\"" + row[i].ToString() + "\"" + ","); 
                } 
                writer.WriteLine(); 
            } 
            // Not sure what to replace this with:
            //Session["exportsCsv"] = sb; 
        } 
        catch (Exception ex) 
        { 
            log4net.Config.XmlConfigurator.Configure(); 
            log.Warn("Logging:" + ex); 
        } 
    }
