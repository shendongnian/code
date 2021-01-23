    public string GetOutline(int indentLevel, XElement element)
    {
        StringBuilder result = new StringBuilder();
    
        result = result.AppendLine(new string('-', indentLevel * 2) + element.Name);
    
        foreach (var childElement in element.Elements())            
            result.Append(GetOutline(indentLevel + 3, childElement));            
    
        return result.ToString();
    }
