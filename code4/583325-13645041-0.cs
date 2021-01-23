    private void button1_Click(object sender, EventArgs e)   
    {      
        // Something to do with the Initialization of the FirstDataTable and SecondDataTable  
        DataTable dt;  
        dt = getDifferentRecords(FirstDataTable, SecondDataTable);  
    
        if (dt.Rows.Count == 0)  
            MessageBox.Show("Equal");  
        else 
            MessageBox.Show("Not Equal");
    }
	// Compare two DataTables and return a DataTable with DifferentRecords       
	/// <summary>       
	/// Compare two DataTables and return a DataTable with DifferentRecords   
	/// </summary>   
	/// <param name="FirstDataTable">FirstDataTable</param>   
	/// <param name="SecondDataTable">SecondDataTable</param>   
	/// <returns>DifferentRecords</returns>
	public DataTable getDifferentRecords(DataTable FirstDataTable, DataTable SecondDataTable)   
	{  
		//Create Empty Table  
		DataTable ResultDataTable = new DataTable("ResultDataTable");  
		//use a Dataset to make use of a DataRelation object  
		using (DataSet ds = new DataSet())  
		{      
			//Add tables      
			ds.Tables.AddRange(new DataTable[] { FirstDataTable.Copy(), SecondDataTable.Copy()  });
			//Get Columns for DataRelation  
			DataColumn[] firstColumns = new DataColumn[ds.Tables[0].Columns.Count];  
			for (int i = 0; i < firstColumns.Length; i++)  
			{  
				firstColumns[i] = ds.Tables[0].Columns[i];  
			}  
			DataColumn[] secondColumns = new DataColumn[ds.Tables[1].Columns.Count];  
			for (int i = 0; i < secondColumns.Length; i++)  
			{  
				secondColumns[i] = ds.Tables[1].Columns[i];  
			}  
			//Create DataRelation  
			DataRelation r1 = new DataRelation(string.Empty, firstColumns, secondColumns, false);  
			ds.Relations.Add(r1);  
			DataRelation r2 = new DataRelation(string.Empty, secondColumns, firstColumns, false);  
			ds.Relations.Add(r2);  
			//Create columns for return table  
			for (int i = 0; i < FirstDataTable.Columns.Count; i++)  
			{  
				ResultDataTable.Columns.Add(FirstDataTable.Columns[i].ColumnName, FirstDataTable.Columns[i].DataType);  
			}  
			//If FirstDataTable Row not in SecondDataTable, Add to ResultDataTable.  
			ResultDataTable.BeginLoadData();  
			foreach (DataRow parentrow in ds.Tables[0].Rows)  
			{  
				DataRow[] childrows = parentrow.GetChildRows(r1);  
				if (childrows == null || childrows.Length == 0)  
					ResultDataTable.LoadDataRow(parentrow.ItemArray, true);  
			}  
			//If SecondDataTable Row not in FirstDataTable, Add to ResultDataTable.  
			foreach (DataRow parentrow in ds.Tables[1].Rows)  
			{  
			  DataRow[] childrows = parentrow.GetChildRows(r2);  
			  if (childrows == null || childrows.Length == 0)  
				ResultDataTable.LoadDataRow(parentrow.ItemArray, true);  
			}  
			ResultDataTable.EndLoadData();  
		}
	    return ResultDataTable;   
	}
