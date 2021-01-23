    public TextPointer[] ExtractStyleChanges(FlowDocument doc)
    {
        var result = new List<TextPointer>();
        foreach(var p in FlowDocument.Blocks.OfType<Paragraph>())
            foreach(var i in p.Inlines)
            {
                result.Add(i.ContentBegin);
            }
        return result.ToArray();            
    }
