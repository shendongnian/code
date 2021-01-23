    //we have a fooBar class with a variety of properties
    private class fooBar
    {
        public List<double[][]> data;
        public IEnumerable<object> dataObj;
        public int integerField;
        public long longProperty { get; set; }
        public string stringValue;
        public int? nullableInt;
        public DateTime dateTimeValue;
    }
    static void Main(string[] args)
    {
        //lets deserialize the following JSON string into our fooBar object, 
        //the dictionary is not necessary, in this case its used to map the "jdata" property
        //on the JSON string to the "data" property of our object
        string JSONstring = "{\"jdata\":[[[1526518800000,7.0],[1526518834200,7.0]],[[1526549272200,25.0],[1526549306400,25.0]]],\"dataObj\":[[[1526518800000,7.0],[1526518834200,7.0]],\"abc\",123],\"integerField\":623,\"longProperty\":456789,\"stringValue\":\"foo\",\"nullableInt\":\"\",\"dateTimeValue\":\"2018-05-17T01:00:00.0000000\"}";
        var mappingDict = new Dictionary<string, string>() { { "jdata", "data" } };
        fooBar myObject = ParseJSON<fooBar>(JSONstring, mappingDict);
    }
