    class ListItemEtlObject : IEquatable<ListITemEtlObject>
    {
      ...
      public void Equals(ListITemEtlObject other) {
        if (other == null) {
          return false;
        }
        return 
          ID == other.ID &&
          ProjectName == other.ProjectName &&
          ProjectType == other.ProjectType &&
          ... ;
      }
    }
