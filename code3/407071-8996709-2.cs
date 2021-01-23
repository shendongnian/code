    public abstract class User
    {
      public bool HasFullAccess
      {
        get { return CanSeeOtherUsersItems && CanEdit; }
      }
      protected abstract bool CanSeeOtherUsersItems {get;}
      protected abstract bool CanEdit {get;}
    }
