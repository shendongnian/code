    private bool IsChildAlreadyAParent(
      string child, 
      string parent, 
      Dictionary<string, List<string>> d )
    {           
        List<string> list;
        if (!d.TryGetValue(child, out list) || list.Count == 0)
        {
            return false;
        }
        if (list[0] == parent)
        {
          return true;
        }
        
        return IsChildAlreadyAParent( childOfChild, parent, d );
    }
