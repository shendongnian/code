    IExcelDataReader reader = null;
    try
    {
    	using (FileStream stream = new FileStream(ofd.FileName, FileMode.Open))
    	{
    		string ext = System.IO.Path.GetExtension(ofd.FileName).Replace(".", "").ToUpper();
    		if (ext == "XLS")
    			reader = ExcelReaderFactory.CreateBinaryReader(stream);
    		else
    			reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
    
    		reader.IsFirstRowAsColumnNames = true;
    		using (DataSet ds = reader.AsDataSet())
    		{
    			foreach (DataRow dr in ds.Tables[0].Rows)
    			{
    				ImportData toAdd = new ImportData()
    					{
    						Format = dr[0].ToString(),
    					};
    
    				Database.Datastore.InsertObject(toAdd);
    			}
    		}
    	}
    }
