    public XElement ToXML()
    {
        var children = new[]
        {
            this.LastName.ToXML(),
            this.FirstName.ToXML(),
            this.MiddleName.ToXML(),
            this.Suffix.ToXML()
        };
    
        return new XElement("Employee", children.Where(x => x != null));
    }
