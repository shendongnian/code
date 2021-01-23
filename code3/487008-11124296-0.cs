    public class FussyDictionary : Dictionary<string,string> {
      // You must provide these values
      public FussyDictionary(string valueA, string valueB) {
         Add("magicKey1", valueA);
         Add("magicKey2", valueB);
      }
      // Override remove to stop you removing these keys?
    }
