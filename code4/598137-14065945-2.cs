    public class MyPageParser
    {
       public int? SomeId { get; private set; } 
       ...
    
    
       pubic IEnumerable<string> Parse(NamedValueCollection params)
       {
          var errors = new List<string>();
          int someId = -1;
          if (!params.TryParseInt("SomeId", out someId))
          {
            errors.Add("Some id not present");
            this.SomeId = null;
          }
          this.SomeId = someId;
    
          ...  
       }
    }
