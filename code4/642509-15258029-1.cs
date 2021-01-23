    private void ReplaceRegex(XElement xElement)
    {
        if(xElement.HasElements)
        {
            foreach (XElement subElement in xElement.Elements())
                this.ReplaceRegex(subElement);
        }
        foreach(var node in xElement.Nodes().OfType<XText>())
        {
            string value = node.Value;
            if(this.ReplaceRegex(ref value))
                node.Value = value;
        }
    }
