    public class YourObject
    {
        public string Field1 { get; set; }
        public string Field2 { get; set; }
    }
    public class YourClass
    {
        public YourObject[] Field { get; set; }
    }
    var yourClass = JsonConvert.DeserializeObject<YourClass>(json);
