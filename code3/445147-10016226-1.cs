    //this is what "ordinary" code uses for read-only access to user info.
    public interface IUser
    {
       string UserName {get;}
       IEnumerable<string> PermissionStrongNames {get;}
       ...
    }
    
    //This class is used for editing user information.
    //It does not implement the interface, and so while editable it cannot be 
    //easily used to "fake" an IUser for authorization
    public sealed class EditableUser 
    {
       public string UserName{get;set;}
       List<SecurityGroup> Groups {get;set;}
       ...
    }
    ...
    //this class is nested within the class responsible for login authentication,
    //which returns instances as IUsers once successfully authenticated
    private sealed class AuthUser:IUser
    {
       private readonly EditableUser user;
       public AuthUser(EditableUser mutableUser) { user = mutableUser; }
       public string UserName {get{return user.UserName;}}
       public IEnumerable<string> PermissionNames 
       {
           //GetPermissions is an extension method that traverses the list of nestable Groups.
           get {return user.Groups.GetPermissions().Select(p=>p.StrongName);
       }
       ...
    }
