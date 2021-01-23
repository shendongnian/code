    try
    {
    	using (MemoryStream stream = new MemoryStream())
    	{
    		// Write the content of the xlsx to the stream
    		gridViewExporter.WriteXlsx(stream, new XlsxExportOptions(TextExportMode.Text, false, false));
    
    		if (Response == null)
    		{
    			return;
    		}
    
    		// Write the byte content to the output
    		Response.Clear();
    		Response.AppendHeader("Content-Disposition", StringMngr.SafeFormat("attachment; filename=\"{0}.xlsx\"", "xlsxFileName"));
    		Response.ContentType = "Text/xlsx";
    		Response.ContentEncoding = System.Text.Encoding.Unicode;
    
    		if (stream.Length > 0)
    		{
    			Response.BinaryWrite(stream.ToArray());
    		}
    
    		Response.Flush();
    		Response.SuppressContent = true;
    	}
    }
    catch (Exception ex)
    {
    	log.Error("An error occured while downloading in xlsx format.", ex);
    }
