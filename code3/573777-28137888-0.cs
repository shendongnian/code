    public static List<T> GetClassFromExcel<T>(string path, int fromRow, int fromColumn, int toColumn = 0)
        {
            List<T> retList = new List<T>();
            using (var pck = new ExcelPackage())
            {
                using (var stream = File.OpenRead(path))
                {
                    pck.Load(stream);
                }
                //Retrieve first Worksheet
                var ws = pck.Workbook.Worksheets.First();
                //If the to column is empty or 0, then make the tocolumn to the count of the properties
                //Of the class object inserted
                toColumn = toColumn == 0 ? typeof (T).GetProperties().Count() : toColumn;
                //Read the first Row for the column names and place into a list so that
               //it can be used as reference to properties
                List<string> columnNames = new List<string>();
                // wsRow = ws.Row(0);
                foreach (var cell in ws.Cells[1,1,1,ws.Cells.Count()])
                {
                    columnNames.Add(cell.Value.ToString());
                }
                //Loop through the rows of the excel sheet
                for (var rowNum = fromRow; rowNum <= ws.Dimension.End.Row; rowNum++)
                {
                    //create a instance of T
                    T objT = Activator.CreateInstance<T>();
                    //Retrieve the type of T
                    Type myType = typeof(T);
                    //Get all the properties associated with T
                    PropertyInfo[] myProp = myType.GetProperties();
                    var wsRow = ws.Cells[rowNum, fromColumn, rowNum, ws.Cells.Count()];
                    foreach (var propertyInfo in myProp)
                    {
                        if(columnNames.Contains(propertyInfo.Name))
                        {
                             int position = columnNames.IndexOf(propertyInfo.Name);
                            //To prevent an exception cast the value to the type of the property.
                            propertyInfo.SetValue(objT, Convert.ChangeType(wsRow[rowNum, position + 1].Value, propertyInfo.PropertyType));
                        }
                    }
                    
                    retList.Add(objT);
                }
            }
            return retList;
        }
