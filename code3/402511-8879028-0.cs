    interface SearchType
    {
       object ProcessList(object list, string text);
    }
    
    class Contains : SearchType
    {
       object ProcessList(object list, string text)
       {
          list = list.Where(a => a.Reference.Contains(text, StringComparison.CurrentCultureIgnoreCase));
       }
    }
