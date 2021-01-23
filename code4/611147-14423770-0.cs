    result.Append(GetOutline(indentLevel + 1, xnodWorking));
    public string GetOutline(int indentLevel, XmlNode xnod)
    {
        StringBuilder result = new StringBuilder();
        XmlNode xnodWorking;
        result = result.AppendLine(new string('-', indentLevel * 2) + xnod.Name);
        if (xnod.HasChildNodes)
        {
            List<string> foundElements = new List<string>();
            xnodWorking = xnod.FirstChild;
            while (xnodWorking != null)
            {
                if(xnodworking.NodeType == XmlNodeType.Element && !foundElements.Contains(xnodworking.Name))
                {
                    result.Append(GetOutline(indentLevel + 1, xnodWorking));
                    foundElements.Add(xnodworking.Name);
                }
                xnodWorking = xnodWorking.NextSibling;
            }
        }
        return result.ToString();
    }                    
