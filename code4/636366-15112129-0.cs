    var testdata = "[{\"name\":\"numToRetrieve\",\"value\":\"3\",\"label\":\"Number of     items       to retrieve:\"},{\"name\":\"showFoo\",\"value\":\"on\",\"label\":\"Show foo?\"},  {\"name\":\"title\",\"value\":\"Foo\",\"label\":\"Foo:\"}]";
           
    DataContractJsonSerializer js = 
    new DataContractJsonSerializer(typeof (List<FooDef>));
    var stream = new MemoryStream(Encoding.UTF8.GetBytes(testdata));
    var foo = js.ReadObject(stream);
    stream.Close();
   
    [DataContract]
    public sealed class FooDef
    {
        [DataMember(Name = "name", IsRequired = true)]
        public string Name { get; set; }
        [DataMember(Name = "value", IsRequired = true)]
        public string Value { get; set; }
        [DataMember(Name = "label", IsRequired = true)]
        public string Label { get; set; }
    } 
