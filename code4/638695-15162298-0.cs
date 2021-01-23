    public class Servicio 
    {
        public int Id { get; set; }
        public int? PartoId { get; set; }
        public virtual Parto Parto { get; set; }
    }
    public class Parto
    {
        public int Id { get; set; }
        public virtual int ServicioId { get; set; }
        [Required]
        public virtual Servicio Servicio { get; set; }        
    }
