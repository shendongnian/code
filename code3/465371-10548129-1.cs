    [DataContract]
    public class MyJSONReturnableClass
    {
        [DataMember]
        public string ThisBecomesANamedString;
        [DataMember]
        public MyJSONReturnableClass[] AndWorksAlsoForNestedArrays;
    }
