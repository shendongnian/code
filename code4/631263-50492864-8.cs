    //we have a foo and bar classes with a variety of fields and properties
    private class foo
    {
        public List<double[][]> data;
        public IEnumerable<object> DataObj;
        public int integerField;
        public long longProperty { get; set; }
        public string stringValue;
        public int? nullableInt;
        public DateTime dateTimeValue;
        public List<bar> classValues;
    }
    private class bar
    {
        public string stringValue;
        public DateTimeOffset dateTimeOffsetValue;
    }
    static void Main(string[] args)
    {
        //lets deserialize the following JSON string into our foo object, 
        //the dictionary is optional, and not necessary if our JSON property names are the same as in our object.
        //in this case it's used to map the "jdata" property on the JSON string to the "data" property of our object,
        //in the case of the "dataObj", we are mapping to the uppercase field of our object
        string JSONstring = "{\"jdata\":[[[1526518800000,7.0],[1526518834200,7.0]],[[1526549272200,25.0],[1526549306400,25.0]]],\"dataObj\":[[[1526518800000,7.0],[1526518834200,7.0]],\"abc\",123],\"integerField\":623,\"longProperty\":456789,\"stringValue\":\"foo\",\"nullableInt\":\"\",\"dateTimeValue\":\"2018-05-17T01:00:00.0000000\", \"classValues\": [{\"stringValue\":\"test\",\"dateTimeOffsetValue\":\"2018-05-17T05:00:00.0000000\"},{\"stringValue\":\"test2\",\"dateTimeOffsetValue\":\"2018-05-17T06:00:00.0000000\"}]}";
        var mappingDict = new Dictionary<string, string>() { { "jdata", "data" }, { "dataObj", "DataObj" } };
        foo myObject = ParseJSON<foo>(JSONstring, mappingDict);
    }
