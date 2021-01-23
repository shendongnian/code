    string[] dataFile = Directory.GetFiles(fullPath);
    DataSet ds = new DataSet();
	DataTable dt = ds.Tables.Add();
	DataRow dr;
	
	dt.Columns.Add("column1"); 
	dt.Columns.Add("column2");
	dt.Columns.Add("column3");
	
	if (dataFile.Count() > 0)
	{
		for (int x = 0; x < dataFile.Count(); x++)
		{		
			using (StreamReader sr = new StreamReader(dataFile[x]))
			{
				while (sr.Peek() != -1)
				{
					string[] fields;
					fields = sr.ReadLine().Split(',');
					if (fields.Count() == 3) // 3 columns
					{
					     dr = dt.NewDataRow();
						 dr["column1"] = fields[0];
						 dr["column2"] = fields[1];
						 dr["column3"] = fields[2];
						 dt.Rows.Add(dr);
					}
				}
			}
		}
	
    }
    
    ds.Tables.Add(dt);
