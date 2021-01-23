    class NameSet
    {
        public IList<string> names { get; set; }
        public string nationality { get; set; }
    }
    var serializer = new JavaScriptSerializer();
    var nameset  = serializer.Deserialize<NameSet>(jsonString);
