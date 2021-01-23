    public sealed class Cultures : List<Culture>
    {
      public Dictionary<string, Culture> ToDictionary()
      {
        return this.ToDictionary(_=>_.Id);
      }
    }
