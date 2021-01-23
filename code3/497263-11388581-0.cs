    class Blah
    {
      public string City {get;set;}
      public string ContactName {get;set;}
    }
    
    ... [rest of query]
    select new Blah {c.City, c.ContactName};
