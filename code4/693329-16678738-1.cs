    // Repository for illustration only
    public class Repo {
      SortedList<string, Entity1> uniqueKey1 = ...; // assuming a unique string column 
      public Entity1 NewEntity1(string keyValue) {
        if (uniqueKey1.ContainsKey(keyValue) throw new ArgumentException ... ;
        return new Entity1 { MyUniqueKeyValue = keyValue };
      }
    }
