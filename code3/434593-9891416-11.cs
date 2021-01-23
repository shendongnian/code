    public class Referencia
    {
        public Int ReferenciaId {get; set;}
        public String Nombre {get; set;}
        //....Other properties of Referencia
        public virtual Persona Persona {get;set;}
    }
