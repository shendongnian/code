    public class Farmacia
    {
        public virtual int Id { get; protected set; }
        public virtual string Nombre { get; set; }
        public virtual string Direccion { get; set; }
        public virtual string Telefono { get; set; }
        public virtual int? CodigoPostal { get; set; }
        public virtual int? Estado { get; set; }
    
        public Farmacia()
        {
        }
    }
