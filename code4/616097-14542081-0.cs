       public class model
        {
            [Key]
            public int Id {get;set;}
            public string Pytanie { get; set; }
            public string A { get; set; }
            public string B { get; set; }
            public string C { get; set; }
            public string D { get; set; }
            public string Prawidlowa_odp { get; set; }
            public int Stawka { get; set; } 
        }
       public class PytaniaModel : DbContext
       {
           public DbSet<model> Modele { get; set; }
       }
