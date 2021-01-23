    [Serializable]
    public class MyClass
    {
        [XmlElement(IsNullable = true)]
        public bool? myBool { get; set; }
    }
