    public class Person{
      [ValidationAttribute(typeof(string), "Required", "true")]
      public string Name{get;set;}
      [ValidationAttribute(typeof(int), "Min", "1")]
      public int Age{get;set;}
    }
