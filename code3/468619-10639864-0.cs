    [TestMethod()]
    [HostType("Moles")]
    public void Test()
    {
        MCspParameters.ConstructorInt32StringStringCspProviderFlags = (
            p, 
            providerType, 
            providerName, 
            keyContainerName, 
            flags) => 
        {
            p.ProviderType = providerType;
            p.ProviderName = providerName;
            p.KeyContainerName = "MyContainerName";
            p.KeyNumber = -1;
            p.Flags = flags;
        };
    
        CspParameters cspParameters = new CspParameters(1);
    
        Assert.AreEqual(cspParameters.ProviderType, 1);
        Assert.AreEqual(cspParameters.KeyContainerName, "MyContainerName");
    }
