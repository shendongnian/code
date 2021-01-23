    SqliteConnection sqlCon = new SqliteConnection("Data Source=" + dataPath + "/Empty.db3");
				sqlCon.Open();
				SqliteCommand sqlCmd = new SqliteCommand(sqlCon);
				DataSet ds = new DataSet();
				ds.ReadXml(Path.Combine(syncPath, tableName + "_4.xml"), XmlReadMode.ReadSchema);
				foreach(DataTable dt in ds.Tables)
				{
					//Get field names
					string sqlString = "INSERT into " + tableName + " (";
					string valString = "";
					var sqlParams = new string[dt.Rows[0].ItemArray.Count()];
					int count = 0;
					foreach(DataColumn dc in dt.Columns)
					{
						sqlString += dc.ColumnName + ", ";
						valString += "@" + dc.ColumnName + ", ";
						sqlParams[count] = "@" + dc.ColumnName;
						count++;
					}
					valString = valString.Substring(0, valString.Length - 2);
					sqlString = sqlString.Substring(0, sqlString.Length - 2) + ") VALUES (" + valString + ")";
					sqlCmd.CommandText = sqlString;
					foreach(DataRow dr in dt.Rows)
					{
						for (int i = 0; i < dr.ItemArray.Count(); i++) 
						{
							sqlCmd.Parameters.AddWithValue(sqlParams[i], dr.ItemArray[i] ?? DBNull.Value);
						}
						sqlCmd.ExecuteNonQuery();
					}
				}
