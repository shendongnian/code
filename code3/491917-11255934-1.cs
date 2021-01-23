    public bool ObjectIsInHighlightedList<T>(object thing)
    {
      foreach (object obj in _highlightedList)
      {
         if (obj is T && thing == (T)obj)
            return true;
      }
    }
