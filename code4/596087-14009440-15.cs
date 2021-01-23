    static void Main(string[] args)
    {
       var optionalParameterInformation = typeof(SomeClass).GetConstructor(new[] { typeof(string), typeof(int), typeof(int) })
       .GetParameters().Select(p => new {p.Name,  OptionalValue = p.RawDefaultValue});
    
       foreach (var p in optionalParameterInformation)
          Console.WriteLine(p.Name+":"+p.OptionalValue);
    
       Console.ReadKey();
    }
