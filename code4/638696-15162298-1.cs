    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    
    namespace CFExamples2
    {
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
    
    
        public class Model : DbContext
        {
            public DbSet<Servicio> Servicios { get; set; }
            public DbSet<Parto> Partos { get; set; }
    
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
               
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
              
    
            }
        }
    }
