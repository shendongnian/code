    private void ReplaceRegex(XElement xElement)
    {
        if(xElement.HasElements)
        {
            foreach (XElement subElement in xElement.Elements())
                this.ReplaceRegex(subElement);
        }
        else
        {
            string value = xElement.Value;
            if(this.ReplaceRegex(ref value))
                xElement.SetValue(value);
        }
    }
