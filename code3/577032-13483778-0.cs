    // By default, Json.Encode will turn an ExpandoObject into an array of items,
    // because internally an ExpandoObject extends IEnumerable<KeyValuePair<string, object>>.
    // You can turn it into a non-list JSON string by first wrapping it in a DynamicJsonObject.
    [TestMethod]
    public void JsonEncodeAnExpandoObjectByWrappingItInADynamicJsonObject()
    {
        dynamic expando = new ExpandoObject();
        expando.Value = 10;
        expando.Product = "Apples";
    
        var expandoResult = System.Web.Helpers.Json.Encode(expando);
        var dictionaryResult = System.Web.Helpers.Json.Encode(new DynamicJsonObject(expando));
    
        Assert.AreEqual("{\"Value\":10,\"Product\":\"Apples\"}", expandoResult); // FAILS (encodes as an array instead)
        Assert.AreEqual("{\"Value\":10,\"Product\":\"Apples\"}", dictionaryResult); // PASSES
    }
