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
