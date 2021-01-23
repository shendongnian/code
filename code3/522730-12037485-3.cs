    public class DictionaryWrapper
    {
       private IDictionary<string, UserInformation> _dict = .... // dictionary is PRIVATE!
    
       public UserInformation GetUserInfo(string key)    // method is PUBLIC
       {
          UserInformation ui;
          _dict.TryGetValue(key, out ui);
          return ui;
       }
    }
