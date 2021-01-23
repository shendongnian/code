    class ComponentComparer : IEqualityComparer<Component>
    {
      public int Compare(Component a, Component b)
      {
        return a.ID.CompareTo(b.ID);
      }
    
      public int GetHashCode(Component a)
      {
        return a.ID.GetHashCode();
      }
    }
