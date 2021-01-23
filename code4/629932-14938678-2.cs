    IEnumerable<string> columnNames = dtResults.Columns
                                               .Cast<DataColumn>()
                                               .Select(column => column.ColumnName);
    
    var res = columnNames.Aggregate((current, next) => "\"" + current + "\"" + ", " + "\"" + next + "\"");
    
    
    File.WriteAllText(saveFileDialog.FileName, res.ToString());
