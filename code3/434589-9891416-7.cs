    public class Persona
    {
        public Persona()
        {
            //Make sure that Referencias is instantiated by default
            Referencias = new List<Referencia>();
        }
        public String Nombres {get; set;}
        //The rest of your properties
        public Int publicIDEmpresa {get; set;}
        //The virtual is here for lazy loading 
        [InverseProperty("PersonaRef")]
        public virtual ICollection<Referencia> Referencias {get; set;}                 
    }
    public class Referencia
    {
        public Int ReferenciaId {get; set;}
        public String Nombre {get; set;}
        //Other properties of Referencia
        public virtual Persona PersonaRef{get;set;}
    }
