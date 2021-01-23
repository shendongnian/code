		// Structures used for conversion between data-types.
		private struct ExcelDataTypes
		{
			public const string NUMBER = "NUMBER";
			public const string DATETIME = "DATETIME";
			public const string TEXT = "TEXT"; // also works with "STRING".
		}
		private struct NETDataTypes
		{
			public const string SHORT = "int16";
			public const string INT = "int32";
			public const string LONG = "int64";
			public const string STRING = "string";
			public const string DATE = "DateTime";
			public const string BOOL = "Boolean";
			public const string DECIMAL = "decimal";
			public const string DOUBLE = "double";
			public const string FLOAT = "float";
		}
		/// <summary>
		/// Routine to export a given DataSet to Excel. For each DataTable contained 
		/// in the DataSet the overloaded routine will create a new Excel sheet based 
		/// upon the currently selected DataTable. The proceedure loops through all 
		/// DataRows in the selected DataTable and pushes each one to the specified 
		/// Excel file using ADO.NET and the Access Database Engine (Excel is not a 
		/// prerequisit).
		/// </summary>
		/// <param name="dataSet">The DataSet to be written to Excel.</param>
		/// <param name="connectionString">The connection string.</param>
		/// <param name="fileName">The Excel file name to export to.</param>
		/// <param name="deleteExistFile">Delete existing file?</param>
		public static void ExportToExcelOleDb(DataSet dataSet, string connectionString, 
														  string fileName, bool deleteExistFile)
		{
			// Support for existing file overwrite.
			if (deleteExistFile && File.Exists(fileName))
				File.Delete(fileName);
			ExportToExcelOleDb(dataSet, connectionString, fileName);
		}
		/// <summary>
		/// Overloaded version of the above.
		/// </summary>
		/// <param name="dataSet">The DataSet to be written to Excel.</param>
		/// <param name="connectionString">The SqlConnection string.</param>
		/// <param name="fileName">The Excel file name to export to.</param>
		public static bool ExportToExcelOleDb(DataSet dataSet, string connectionString, string fileName)
		{
			try
			{
				// Check for null set.
				if (dataSet != null && dataSet.Tables.Count > 0)
				{
					using (OleDbConnection connection = new OleDbConnection(String.Format(connectionString, fileName)))
					{
						// Initialise SqlCommand and open.
						OleDbCommand command = null;
						connection.Open();
						// Loop through DataTables.
						foreach (DataTable dt in dataSet.Tables)
						{
							// Build the Excel create table command.
							string strCreateTableStruct = BuildCreateTableCommand(dt);
							if (String.IsNullOrEmpty(strCreateTableStruct))
								return false;
							command = new OleDbCommand(strCreateTableStruct, connection);
							command.ExecuteNonQuery();
							// Puch each row into Excel.
							for (int rowIndex = 0; rowIndex < dt.Rows.Count; rowIndex++)
							{
								command = new OleDbCommand(BuildInsertCommand(dt, rowIndex), connection);
								command.ExecuteNonQuery();
							}
						}
					}
				}
				return true;
			}
			catch (Exception eX)
			{
				Utils.ErrMsg(eX.Message);
				return false;
			}
		}
		/// <summary>
		/// Build the various sheet names to be inserted based upon the 
		/// number of DataTable provided in the DataSet. This is not required
		/// for XCost purposes. Coded for completion.
		/// </summary>
		/// <param name="connectionString">The connection string.</param>
		/// <returns>String array of sheet names.</returns>
		private static string[] BuildExcelSheetNames(string connectionString)
		{
			// Variables.
			DataTable dt = null;
			string[] excelSheets = null;
			using (OleDbConnection schemaConn = new OleDbConnection(connectionString))
			{
				schemaConn.Open();
				dt = schemaConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
				// No schema found.
				if (dt == null)
					return null;
				// Insert 'TABLE_NAME' to sheet name array.
				int i = 0;
				excelSheets = new string[dt.Rows.Count];
				foreach (DataRow row in dt.Rows)
					excelSheets[i++] = row["TABLE_NAME"].ToString();
			}
			return excelSheets;		
		}
		/// <summary>
		/// Routine to build the CREATE TABLE command. The conversion of 
		/// .NET to Excel data types is also handled here (supposedly!). 
		/// Help: http://support.microsoft.com/kb/316934/en-us.
		/// </summary>
		/// <param name="dataTable"></param>
		/// <returns>The CREATE TABLE command string.</returns>
		private static string BuildCreateTableCommand(DataTable dataTable)
		{
			// Get the type look-up tables.
			StringBuilder sb = new StringBuilder();
			Dictionary<string, string> dataTypeList = BuildExcelDataTypes();
			// Check for null data set.
			if (dataTable.Columns.Count <= 0)
				return null;
			// Start the command build.
			sb.AppendFormat("CREATE TABLE [{0}] (", BuildExcelSheetName(dataTable));
			// Build column names and types.
			foreach (DataColumn col in dataTable.Columns)
			{
				string type = ExcelDataTypes.TEXT;
				if (dataTypeList.ContainsKey(col.DataType.Name.ToString().ToLower()))
				{
					type = dataTypeList[col.DataType.Name.ToString().ToLower()];
				}
				sb.AppendFormat("[{0}] {1},", col.Caption.Replace(' ', '_'), type);
			}
			sb = sb.Replace(',', ')', sb.ToString().LastIndexOf(','), 1);
			return sb.ToString();	
		}
		/// <summary>
		/// Routine to construct the INSERT INTO command. This does not currently 
		/// work with the data type miss matches.
		/// </summary>
		/// <param name="dataTable"></param>
		/// <param name="rowIndex"></param>
		/// <returns></returns>
		private static string BuildInsertCommand(DataTable dataTable, int rowIndex)
		{
			StringBuilder sb = new StringBuilder();
			// Remove whitespace.
			sb.AppendFormat("INSERT INTO [{0}$](", BuildExcelSheetName(dataTable));
			foreach (DataColumn col in dataTable.Columns)
				sb.AppendFormat("[{0}],", col.Caption.Replace(' ', '_'));
			sb = sb.Replace(',', ')', sb.ToString().LastIndexOf(','), 1);
			
			// Write values.
			sb.Append("VALUES (");
			foreach (DataColumn col in dataTable.Columns)
			{
				string type = col.DataType.ToString();
				string strToInsert = String.Empty;
				strToInsert = dataTable.Rows[rowIndex][col].ToString().Replace("'", "''");
				sb.AppendFormat("'{0}',", strToInsert);
				//strToInsert = String.IsNullOrEmpty(strToInsert) ? "NULL" : strToInsert;
				//String.IsNullOrEmpty(strToInsert) ? "NULL" : strToInsert);
			}
			sb = sb.Replace(',', ')', sb.ToString().LastIndexOf(','), 1);
			return sb.ToString();
		}
		/// <summary>
		/// Build the Excel sheet name.
		/// </summary>
		/// <param name="dataTable"></param>
		/// <returns></returns>
		private static string BuildExcelSheetName(DataTable dataTable)
		{
			string retVal = dataTable.TableName;
			if (dataTable.ExtendedProperties.ContainsKey(TABLE_NAME_PROPERTY))
				retVal = dataTable.ExtendedProperties[TABLE_NAME_PROPERTY].ToString();
			return retVal.Replace(' ', '_');
		}
        		/// <summary>
		/// Dictionary for conversion between .NET data types and Excel 
		/// data types. The conversion does not currently work, so I am 
		/// pushing all data upto excel as Excel "TEXT" type.
		/// </summary>
		/// <returns></returns>
		private static Dictionary<string, string> BuildExcelDataTypes()
		{
			Dictionary<string, string> dataTypeLookUp = new Dictionary<string, string>();
			// I cannot get the Excel formatting correct here!?
			dataTypeLookUp.Add(NETDataTypes.SHORT, ExcelDataTypes.NUMBER);
			dataTypeLookUp.Add(NETDataTypes.INT, ExcelDataTypes.NUMBER);
			dataTypeLookUp.Add(NETDataTypes.LONG, ExcelDataTypes.NUMBER);
			dataTypeLookUp.Add(NETDataTypes.STRING, ExcelDataTypes.TEXT);
			dataTypeLookUp.Add(NETDataTypes.DATE, ExcelDataTypes.DATETIME);
			dataTypeLookUp.Add(NETDataTypes.BOOL, ExcelDataTypes.TEXT);
			dataTypeLookUp.Add(NETDataTypes.DECIMAL, ExcelDataTypes.NUMBER);
			dataTypeLookUp.Add(NETDataTypes.DOUBLE, ExcelDataTypes.NUMBER);
			dataTypeLookUp.Add(NETDataTypes.FLOAT, ExcelDataTypes.NUMBER);
			return dataTypeLookUp;
		}
