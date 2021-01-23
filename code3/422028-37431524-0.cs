    public static FlowDocument ToFlowDocument(string xmlString)
    {
        var result = new FlowDocument();
        if (!string.IsNullOrEmpty(xmlString))
        {
            result.Blocks.Add((Section)XamlReader.Parse(xmlString));
        }
        return result;        
    }
