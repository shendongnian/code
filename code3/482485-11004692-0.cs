    void Main()
    {
           
       TestIt tbTrue = new TestIt() { BValue = true }; // Comment out assignment to see null
    
       var result =
        tbTrue.GetType()
              .GetProperties()
              .FirstOrDefault( prp => prp.Name == "BValue" )
              .GetValue( tb, null ) ?? false.ToString();
    
          Console.WriteLine ( result ); // True
    
    }
    
    public class TestIt
    {
       public bool? BValue { get; set; }
    }
