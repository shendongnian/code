    public class Persona
    {
        public Persona()
        {
            //Make sure that Referencias is instantiated by default
            Referencias = new List<Referencia>();
        }
        public String Nombres {get; set;}
        //...The other properties of Persona
        public Int publicIDEmpresa {get; set;}
        //The virtual is here for lazy loading 
        [InverseProperty("PersonaRef")]
        public virtual ICollection<Referencia> Referencias {get; set;} 
    }
