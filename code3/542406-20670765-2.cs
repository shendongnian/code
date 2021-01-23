    [DataContract]
    public class Persona
    {
        [DataMember]
        [Key]
        public int IdPersona { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public List<Domicilio> Domicilios { get; set; }
    }
    [DataContract]
    public class Domicilio
    {
        [DataMember]
        [Key]
        public int IdDomicilio { get; set; }
        [DataMember]
        public Persona persona { get; set; }
    }
