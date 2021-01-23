    XDocument xdoc = XDocument.Load(path_to_xml);
    var tables = xdoc.Root.Elements()
                     .Select(report => {
                         DataTable table = new DataTable(report.Name.LocalName);
                         var fields = report
                                .Descendants("Row")
                                .SelectMany(row => row.Elements()
                                                      .Select(e => e.Name.LocalName))
                                .Distinct();
    
                         foreach(string field in fields)
                             table.Columns.Add(field);
    
                         foreach(var row in report.Descendants("Row"))
                         {
                             DataRow dr = table.NewRow();
                             foreach(var field in row.Elements())
                                 dr[field.Name.LocalName] = (string)field;
                             table.Rows.Add(dr);
                         }                                   
    
                         return table;
                    });
