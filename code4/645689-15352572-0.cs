    public void AssertElementExistsWithValue(XmlElement parent, string nameSpace, string childName, string value)
    {
        var child = parent.Element(namespace + childName);
        Assert.IsNotNull(child);
        Assert.AreEqual(child.Value, "600");    
    }
