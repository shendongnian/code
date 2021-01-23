    foreach (XElement node in csvDocument.Descendants("Sample"))
    {
        foreach (XElement innerNode in node.Elements())
        {
            //    this logic assumes different formatting for values
            //    otherwise, change if statement to || each comparison
            if(innerNode.Name == "ID") {
                // append/format stringBuilder
                continue;
            }
            
            if(innerNode.Name == "Selected") {
                // append/format stringBuilder
                continue;
            }
        }
        csvBuilder.Remove(csvBuilder.Length -1, 1);
        csvBuilder.AppendLine();
    }
