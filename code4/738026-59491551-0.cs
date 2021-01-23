        using (dsSomeDataSet dsList = new dsSomeDataSet())
    {
    	using (System.Data.SqlClient.SqlCommand sqlCmd = new System.Data.SqlClient.SqlCommand())
        	{
        
    		//blah blah blah take care of parameter definitions for the stored proc
        
    		using (SqlDataReader sqlReader = sqlCmd.ExecuteReader())
        		{
        			while (sqlReader.Read())
        			{
        				//populate each returning row
        				dsSomeDataSet.tATablesRow rowNote = dsList.tATable.tATablesRow();
        				
    				//using the actual field name, strongly typed, required using the declared dataset variable, not the dataset object				
        				rowNote.ThisField'sName = new Guid(sqlReader[ dsList.tATable.ThisField'sName.ColumnName].ToString() );
        				
    				dsList.tNotes.AddtNotesRow( rowNote );
        			}
        			sqlReader.Close();
        		}
        
        
        	}   //releases the command resources
        }   //releases the dataset resources
