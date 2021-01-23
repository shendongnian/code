     public class MovieResponse
     {
          public string Name {get;set;}
          public int Id {get;set;}
          public double Gross {get;set;}
          [NonSerialized()]
          public string Director {get;set;}
          [NonSerialized()]
          public Rating Rating {get;set;}
     }
