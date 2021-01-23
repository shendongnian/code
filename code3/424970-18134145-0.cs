    [TestMethod]
    public void TestSomething()
    {
        using(ShimsContext.Create()) {
            const string key = "key";
            const string value = "value";
            ShimConfigurationManager.AppSettingsGet = () =>
            {
                NameValueCollection nameValueCollection = new NameValueCollection();
                nameValueCollection.Add(key, value);
                return nameValueCollection;
            };
    
            ///
            // Test code here.
            ///
    
            // Validation code goes here.        
        }
    }
