    public abstract class User
    {
      private bool _hasFullAccess;
      protected User()
      {
        _hasFullAccess = CanSeeOtherUsersItems && CanEdit;
      }
      public bool HasFullAccess
      {
        get { return _hasFullAccess; }
      }
      protected abstract bool CanSeeOtherUsersItems {get;}
      protected abstract bool CanEdit {get;}
    }
    public class Admin : User
    {
      protected override bool CanSeeOtherUsersItems
      {
        get { return true; }
      }
      protected override bool CanEdit
      {
        get { return true; }
      }
    }
    public class Auditor : User
    {
      protected override bool CanSeeOtherUsersItems
      {
        get { return true; }
      }
      protected override bool CanEdit
      {
        get { return false; }
      }
    }
