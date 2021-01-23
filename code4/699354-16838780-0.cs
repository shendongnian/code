    [DataContract(Namespace="")]
    public class Event
    {
        [DataMember]
        public string Name { get; set; }
        
        [DataMember(EmitDefaultValue=false)]
        public IList<Division> Divisions { get; set; }
    }
