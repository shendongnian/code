    public class Parser
    {
          protected static IDictionary<String, Regex> PhrasesToRegexp { get; set; }
          ...
    }
    public class MockParser : Parser
    {
         public MockParser() : base()
         {
         }
         public void AddPhraseToRegexp(String key, Regex value)
         {
             // Add it
             PhrasesToRegexp.Add(key, value);
         }
         public void CreatePhrasesToRegexp(IDictionary<String, Regex> newDict)
         {
             // Create a new Dictionary
             PhrasesToRegexp = newDict;
         }
    }
