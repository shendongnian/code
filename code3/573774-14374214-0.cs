    public static List<T> getClassFromExcel<T>(string path, int fromRow, int fromColumn, int toColumn = 0) where T : class
    		{
    			using (var pck = new OfficeOpenXml.ExcelPackage())
    			{
    				List<T> retList = new List<T>();
    
    				using (var stream = File.OpenRead(path))
    				{
    					pck.Load(stream);
    				}
    				var ws = pck.Workbook.Worksheets.First();
    				toColumn = toColumn == 0 ? typeof(T).GetProperties().Count() : toColumn;
    				
    				for (var rowNum = fromRow; rowNum <= ws.Dimension.End.Row; rowNum++)
    				{
    					T objT = Activator.CreateInstance<T>();
    					Type myType = typeof(T);
    					PropertyInfo[] myProp = myType.GetProperties();
    
    					var wsRow = ws.Cells[rowNum, fromColumn, rowNum, toColumn];
    
    					for (int i = 0; i < myProp.Count(); i++)
    					{
    						myProp[i].SetValue(objT, wsRow[rowNum, fromColumn + i].Text);
    					}
    					retList.Add(objT);
    				}
    				return retList;
    			}
    		}
