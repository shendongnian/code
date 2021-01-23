    void Main()
    {
      // make sure that we only take public static const
      // used loop, but can easily be converted to list where linq could be used
      foreach (FieldInfo field in typeof(Supplier).GetFields(BindingFlags.Static | BindingFlags.Public).Where(i => i.IsLiteral))
      {
        string val = field.GetRawConstantValue().ToString();
        Console.WriteLine("is " + val + " found: " + (val == "companyA"));
      }
    }
    
    // Define other methods and classes here
    public struct Supplier {
    	public const string
    		NA = "N/A",
    		companyA = "companyA",
    		companyB = "companyB";
    };
