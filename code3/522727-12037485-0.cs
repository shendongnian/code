    public class DictionaryWrapper
    {
       private IDictionary<string, UserInformation> dic = .... //dictionary is PRIVATE !
    
    
       public UserInformation GetUSerInfo(string key)    // method is PUBLIC
       {
          UserInformation ui = null;
          dic.TryGetValue(key, out ui);
          retur ui;
       }
    
    }
