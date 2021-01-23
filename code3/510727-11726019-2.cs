    void Main()
    {
      // make sure that we only take public static const
      string phrase = "companyA";
      var fields = typeof(Supplier).GetFields(BindingFlags.Static | BindingFlags.Public).Where(i => i.IsLiteral);
      foreach (FieldInfo field in fields)
      {
        string val = field.GetRawConstantValue().ToString();
        string msg = string.Format("is '{0}' equal to '{1}' => {2}", val, phrase, val == phrase);
        Console.WriteLine(msg);
      }
    }
    
    // Define other methods and classes here
    public struct Supplier {
    	public const string
    		NA = "N/A",
    		companyA = "companyA",
    		companyB = "companyB";
    };
