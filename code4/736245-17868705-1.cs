    using System.Data.DataSetExtensions;
                
    var XDocument doc = new XDocument();
    var root =  new XElement("Filters");
                        
    var items = dt.Rows.AsIEnumberable().Select(row=> new XElement("StringFilter",             new XAttribute("cname",(string) row["cname"]),
        /*additional attributes here*/
         (string) row["text"]  ));
                        
    root.Add(items);
    doc.Add(root);
