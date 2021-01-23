    public class Permission
    {
      public ID { get; set; }
      public ParentID { get; set; }
      public Name { get; set; }
    }
    int userPermissionID = 3;  // Division two
    int objectPermissionID = 7; // Department 2.2
    bool hasAccess = false;
    List<int> check = new List<int>();
    check.add(objectPermissionID);
    hasAccess = userPermissionID == objectPermissionID;
    while(!hasAccess && check.count > 0)
    {
      var permissions = context.Permissions
        .Where(p => check.Contains(p.ParentID))
        .ToList();
      hasAccess = permissions.Any(p => p.ID = userPermissionID)
                  || permissions.Any(p => p.ParentID = userPermissionID)
      check = permissions.Select(p => p.ParentID).ToList();
    }
    if (hasAccess)
    {
      ..
