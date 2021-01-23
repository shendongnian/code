    public static IEnumerable<T> FindChildren<T>(this DependencyObject source)
                                                 where T : DependencyObject
    {
      if (source != null)
      {
        var childs = GetChildObjects(source);
        foreach (DependencyObject child in childs)
        {
          //analyze if children match the requested type
          if (child != null && child is T)
          {
            yield return (T) child;
          }
    
          //recurse tree
          foreach (T descendant in FindChildren<T>(child))
          {
            yield return descendant;
          }
        }
      }
    }
