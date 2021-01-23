    [System.Xml.Serialization.XmlElementAttribute("Warnings", typeof(WarningsType))]
    public object[] Items
    {
        get
        {
            return this.itemsField;
        }
        set
        {
            this.itemsField = value;
        }
    }
