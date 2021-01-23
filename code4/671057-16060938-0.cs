    public class Request
    {
        public string Result
        {
          get{ 
               if(result != null && !string.IsNullOrEmpty(result))
                    return result;
               return null;
             }
        }
      ...
    }
