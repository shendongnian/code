    [TestMethod]
    public void RunMyDataProviderTest()
            {
                DataProvider dataProvider = Data.Provider;
                
                Assert.IsInstanceOfType(dataProvider, typeof(MyDataProvider));
    
                Assert.AreEqual(dataProvider.MyAttribute1, "MyValue1");
                Assert.AreEqual(dataProvider.MyAttribute2, "MyValue2");
    }
