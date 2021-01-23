       if (doc.ParseErrors!=null && doc.ParseErrors.Count>0)
       {
           // Handle any parse errors as required
       }
       else
       {
            if (doc.DocumentNode != null)
            {
                HtmlNode fontNode = doc.DocumentNode.SelectSingleNode("//font");
                if (fontNode != null)
                {
                    // Do something with fontNode
                    MessageBox.Show(fontNode.InnerText);
                }
            }
        }
