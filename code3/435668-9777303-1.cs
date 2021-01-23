    void StreamExcelFile(byte[] bytes)
    {
    	Response.Clear();
    	Response.ContentType = "application/force-download";
    	Response.AddHeader("content-disposition", "attachment; filename=name_you_file.xls");
    	Response.BinaryWrite(bytes);
    	Response.End();
    }
