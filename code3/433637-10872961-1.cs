    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Agent", typeof(BaseTestTypeAgent))]
    [System.Xml.Serialization.XmlElementAttribute("Css", typeof(BaseTestTypeCss))]
    [System.Xml.Serialization.XmlElementAttribute("DeploymentItems", typeof(BaseTestTypeDeploymentItems))]
    [System.Xml.Serialization.XmlElementAttribute("Description", typeof(object))]
    [System.Xml.Serialization.XmlElementAttribute("Execution", typeof(BaseTestTypeExecution))]
    [System.Xml.Serialization.XmlElementAttribute("Owners", typeof(BaseTestTypeOwners))]
    [System.Xml.Serialization.XmlElementAttribute("Properties", typeof(BaseTestTypeProperties))]
    [System.Xml.Serialization.XmlElementAttribute("TcmInformation", typeof(TcmInformationType))]
    [System.Xml.Serialization.XmlElementAttribute("TestCategory", typeof(BaseTestTypeTestCategory))]
    [System.Xml.Serialization.XmlElementAttribute("WorkItemIDs", typeof(WorkItemIDsType))]
    [System.Xml.Serialization.XmlElementAttribute("IncludedWebTests", typeof(CodedWebTestElementTypeIncludedWebTests))]
    [System.Xml.Serialization.XmlElementAttribute("WebTestClass", typeof(CodedWebTestElementTypeWebTestClass))]
    public object[] Items
    {
        get {
            return this.itemsField;
        }
        set {
            this.itemsField = value;
        }
    }
