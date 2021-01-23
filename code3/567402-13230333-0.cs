        using (var reader = new StringReader(StrHtml))
        {
           var doc = XDocument.Load(reader);
           var table = doc.Descendants("table").FirstOrDefault();
           if (table != null)
           {
               var style = table.Attribute("Style");
               if (style != null)
                   style.Value = "width:550px";
           }
        }
