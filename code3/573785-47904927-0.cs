    public static List<T> GetClassFromExcel<T>(string path, int fromRow, int fromColumn, int toRow = 0, int toColumn = 0) where T: class, new()
    {
            if (toColumn != 0 && toColumn < fromColumn) throw new Exception("toColumn can not be less than fromColumn");
            if (toRow != 0 && toRow < fromRow) throw new Exception("toRow can not be less than fromRow");
            List<T> retList = new List<T>();
            using (var pck = new ExcelPackage())
            {
                using (var stream = File.OpenRead(path))
                {
                    pck.Load(stream);
                }
                //Retrieve first Worksheet
                var ws = pck.Workbook.Worksheets.First();
                
                toColumn = toColumn == 0 ? typeof(T).GetProperties().Count() : toColumn; //If the to column is empty or 0, then make the tocolumn to the count of the properties Of the class object inserted
                //Read the first Row for the column names and place into a list so that
                //it can be used as reference to properties
                Dictionary<string, int> columnNames = new Dictionary<string, int>();
                // wsRow = ws.Row(0);
                var colPosition = 0;
                foreach (var cell in ws.Cells[1, 1, 1, toColumn == 0 ? ws.Dimension.Columns : toColumn])
                {
                    columnNames.Add(cell.Value.ToString(), colPosition);
                    colPosition++;
                }
               
                //Retrieve the type of T
                Type myType = typeof(T);
                //Get all the properties associated with T
                PropertyInfo[] myProp = myType.GetProperties();
                //Loop through the rows of the excel sheet
                for (var rowNum = fromRow + 1; rowNum <= (toRow == 0 ? ws.Dimension.End.Row : toRow); rowNum++) // fromRow + 1 to read from next row after columnheader
                {
                    //create a instance of T
                    //T objT = Activator.CreateInstance<T>();
                    T objT = new T();
                    // var wsRow = ws.Cells[rowNum, fromColumn, rowNum, ws.Cells.Count()]; //ws.Cells.Count() causing out of range error hence using ws.Dimension.Columns to get last column index 
                    var wsRow = ws.Cells[rowNum, fromColumn, rowNum, ws.Dimension.Columns];
                    foreach (var propertyInfo in myProp)
                    {
                        var attribute = propertyInfo.GetCustomAttributes(typeof(DisplayNameAttribute), true).Cast<DisplayNameAttribute>().SingleOrDefault();
                        string displayName = attribute != null && !string.IsNullOrEmpty(attribute.DisplayName) ? attribute.DisplayName : propertyInfo.Name; // If DisplayName annotation not used then get property name itself                       
                        if (columnNames.ContainsKey(displayName))
                        {
                            int position = 0;                           
                            columnNames.TryGetValue(displayName, out position);
                            ////int position = columnNames.IndexOf(propertyInfo.Name);
                            ////To prevent an exception cast the value to the type of the property.
                            propertyInfo.SetValue(objT, Convert.ChangeType(wsRow[rowNum, position + 1].Value, propertyInfo.PropertyType));
                        }
                    }                   
                    retList.Add(objT);
                }
            }
            return retList;
        }
    //IMPLEMENTATION DONE BY PLACING Code IT IN SEPARATE Helpers.CS file  and 
    //Consuming it in this manner
    List<CustomerExcelModel> records = 
    Helpers.GetClassFromExcel<CustomerExcelModel>(filelocation, 1, 1);
