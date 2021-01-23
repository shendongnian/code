    public class MyClass
    {
       // known field
       public decimal TaxRate { get; set; }
 
       // extra fields
       [JsonExtensionData]
       private IDictionary<string, JToken> _extraStuff;
    }
