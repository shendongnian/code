    [Flags]
    enum Permissions 
    { 
       None = 0, 
       View = 1, 
       Edit = 2, 
       Delete = 4, 
       Add = 8, 
    }
    
    var permissions = 
      (add ? Permissions.Add : Permissions.None) +
      (edit ? Permissions.Edit : Permissions.None) +
      (delete ? Permissions.Delete : Permissions.None);
