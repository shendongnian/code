    var doc = XElement.Load(@"path to your xml");
    var result = doc.Nodes()
        .Cast<XElement>()
        .Select(n=>
        {
            var columnsDlElement = n.FirstNode as XElement;
            var iColumnElement = columnsDlElement.FirstNode as XElement;
            return new
            {
                Rows = Convert.ToInt32(n.Attribute("IRows").Value),
                Columns = Convert.ToInt32(columnsDlElement.Attribute("Columns").Value),
                IColumn = iColumnElement.Value
             };
         });
