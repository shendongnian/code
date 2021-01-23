    public class PermissionManager{
     private PermissionManager(){userPermissionSet =new List<permissionTemp>();}
     private PermissionManager _instance
     public PermissionManager Instance{
      get{ 
       if (_instance==null) _instance=new PermissionManager();
       return _instance;
      }
     public List<permissionTemp> UserPermissionSet { get; private set; }
     }
    }
