    public class IndexedClass
    {
      private List<String> _content;
      public IndexedClass()
      {
         _content = new List<String>();
      }
      public Add(String argValue)
      {
         _content.Add(argValue);
      }
    
      public string this[int index]
      {
         get
         {
            return _content[index];
         }
         set
         {
             _content[Index] = value;
         }
      }
    }
