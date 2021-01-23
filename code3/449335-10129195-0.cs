     public class MyFilterModel
     {
         public string Dominio { get; set; } 
         public string Cliente { get; set; } 
         public DateTime? Desde { get; set; } 
         public int? Estado { get; set; } 
         public string Origen { get; set; } 
         public int? Reclamoid { get; set; }  
     }
     public class MyViewModel
     {
          public MyFilterModel Filters {get;set;}
          public IEnumerable<DataRow> Results {get;set;}
     }
