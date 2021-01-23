           List<string> items = new List<string>();
              XmlReader rdr = XmlReader.Create(new System.IO.StringReader(xml));
              while (rdr.Read())
              {
                if (rdr.NodeType == XmlNodeType.Element)
                {
                    InsertHTML(rdr.LocalName.ToString(), rdr.Value.ToString());
                }
              }
            private void InsertHTML(string name, string value)
            {
                if (value == string.Empty)
                    return;
                if(name=="AssociatedItems")
                 {
                  
                   items.add(value);
                 }
                 else
                 {
                pnl.ContentTemplateContainer.Controls.Add(new LiteralControl(String.Format("<h3>{0}</h3>", name)));
                pnl.ContentTemplateContainer.Controls.Add(new LiteralControl(String.Format("<p>{0}</p>", value)));
                 }
            }
               pnl.ContentTemplateContainer.Controls.Add(new LiteralControl(String.Format("<h3>{0}</h3>", "Associated Items")));
               pnl.ContentTemplateContainer.Controls.Add(new LiteralControl(String.Format("<ul>")));
            foreach(var item in items)
            {
            
              pnl.ContentTemplateContainer.Controls.Add(new LiteralControl(String.Format("<li>{0}</li>", item)));
            
            }
             pnl.ContentTemplateContainer.Controls.Add(new LiteralControl(String.Format("</ul>")));
