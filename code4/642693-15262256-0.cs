    XDocument doc = XDocument.Parse(input);
    
             var nodes = doc.Element(rootNode).Descendants()
                 .Where(n => (n.Value != "0" && n.Value != ".00" && n.Value != "false" && n.Value != "") || n.HasElements)
                 .Select(n => new { n.Name, n.Value, Level = n.Ancestors().Count() - 1, 
                    n.HasElements, Descendants = n.Descendants().Count(), 
                    FirstChildValue = n.HasElements?n.Descendants().FirstOrDefault().Value:"" });
    
             var output = new StringBuilder();
            
             foreach (var node in nodes)
             {            
                if (node.HasElements)
                {               
                   output.AppendLine(new string(' ', node.Level) + node.Name.ToString() + ":");
                   if (0 == node.Level && 1 == node.Descendants && String.IsNullOrWhiteSpace(node.FirstChildValue))
                      output.AppendLine("");
                }
