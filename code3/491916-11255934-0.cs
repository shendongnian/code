    public bool ObjectIsInHighlightedList(object thing, Type passedType)
    {
      foreach (object obj in _highlightedList)
      {
         if (passedType.IsAssignableFrom(obj.GetType()) && (object)thing == obj)
            return true;
      }
    }
