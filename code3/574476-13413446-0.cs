    [Serializable]
     class Employee : ISerializable
     {
       [NonSerialized]
       [XmlIgnore]
       public Department Department { get; set; }
