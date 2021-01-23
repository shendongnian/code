    var table = new DataTable();
                var column = new DataColumn("col1");
    
                table.Columns.Add(column);
    
                var row = table.NewRow();
                row[0] = @"<configuration><Store parameter=""Atribs"">AB,CD</Store></configuration>";
                table.Rows.Add(row);
    
                row = table.NewRow();
                row[0] = @"<configuration><Store parameter=""Atribs"">EF,GH,IJ</Store></configuration>";
                table.Rows.Add(row);
    
                var data = new List<List<string>>();
    
                foreach (DataRow dRow in table.Rows)
                {
                    var temp = new List<string>();
                    string xml = dRow.Field<string>("col1");
    
                    var element = XElement.Parse(xml);
                    string[] values = element.Descendants("Store").First().Value.Split(',');
    
                    temp.AddRange(values);
                    data.Add(temp);
                }
