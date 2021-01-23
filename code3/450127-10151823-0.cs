    [DataContract]
    public class MyObjet
    {
        [DataMember(EmitDefaultValue = false)]
        public string Prop1 { get; set; }
    
        [DataMember(EmitDefaultValue = false)]
        public string Prop2 { get; set; }
    }
