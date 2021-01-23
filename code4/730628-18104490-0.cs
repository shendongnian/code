		/// <summary>
		///  Allows the programmer to easily update rows in the DB.
		/// </summary>
		/// <param name="tableName">The table to update.</param>
		/// <param name="data">A dictionary containing Column names and their new values.</param>
		/// <param name="where">The where clause for the update statement.</param>
		/// <returns>A boolean true or false to signify success or failure.</returns>
		public bool Update(String tableName, Dictionary<String, String> data, String where)
		{
			String vals = "";
			Boolean returnCode = true;
			
			//Need to determine the dataype of fields to update as this affects the way the sql needs to be formatted
			String colQuery = "PRAGMA table_info(" + tableName + ")";
			DataTable colDataTypes = GetDataTable(colQuery);
			
			
			if (data.Count >= 1)
			{
				foreach (KeyValuePair<String, String> pair in data)
				{
					
					DataRow[] colDataTypeRow = colDataTypes.Select("name = '" + pair.Key.ToString() + "'");
					
					String colDataType="";
					if (pair.Key.ToString()== "rowid" || pair.Key.ToString()== "_rowid_" || pair.Key.ToString()=="oid")
					{
						colDataType = "INT";
					}
					else
					{
						colDataType = colDataTypeRow[0]["type"].ToString();
	
					}
					colDataType = colDataType.Split(' ').FirstOrDefault();
					if ( colDataType == "VARCHAR")
					{
						colDataType = "VARCHAR";
					}
					
					switch(colDataType)
					{
						case "INTEGER": case "INT": case "NUMERIC": case "REAL":
								vals += String.Format(" {0} = {1},", pair.Key.ToString(), pair.Value.ToString());
								break;
						case "TEXT": case "VARCHAR": case "DATE": case "DATETIME":
								vals += String.Format(" {0} = '{1}',", pair.Key.ToString(), pair.Value.ToString());
								break;
							
					}
				}
				vals = vals.Substring(0, vals.Length - 1);
			}
			try
			{
				string sql = String.Format("update {0} set {1} where {2};", tableName, vals, where);
				//dbl.AppendLine(sql);
				dbl.AppendLine(sql);
				this.ExecuteNonQuery(sql);
			}
			catch(Exception crap)
			{
				OutCrap(crap);
				returnCode = false;
			}
			return returnCode;
		}
