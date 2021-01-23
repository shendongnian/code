        var ele = XElement.Parse(xml);
        // change to XElement.Load if loading from file  
        var result = ele.Descendants("Section").Zip(ele.Descendannt("Mark"),  (s,m) => new {Section = s.Value, Mark = m.Value}); Now you can create your DataTable:
        var table = new DataTable(); 
        var marks = new DataColumn("Mark");
        var sections = new     DataColumn("Sections"); 
        table.Columns.Add(marks); table.Columns.Add(sections); 
        foreach (var item in result) 
        {   
         var row = table.NewRow();   
         row["Mark"] = item.Mark;     
         row["Sections"] = item.Section; 
         table.Rows.Add(row);
        } 
