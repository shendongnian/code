    public void AssignUserGroup(int id, string[] selectedUsers, string[] currentusernames)
    {
        if (id < 1) throw new ArgumentExpcetion("id");
        if (selectedUsers.Length == 0) throw new ArgumentException("selectedUsers");
        if (currentusernames.Length == 0) throw new ArgumentException("currentusernames");
        var usergroups = tms.UserGroups.Where(a=>a.GroupID == id);
        // May need to user .Count instead of .Length
        if (usergroups == null || usergroups.Length == 0) throw new ArgumentOutOfRangeException("id");
        foreach (var ug in usergroups)
        {
           if (currentusernames != null)
           {
              for (int c = 0; c < currentusernames.Count(); c++)
              {
                  if (ug.UserName == currentusernames[c])
                  {
                      tms.UserGroups.Remove(ug);
                  }
              }
           }
        }
        if( selectedUsers !=null)
        {
           for (int i = 0; i < selectedUsers.Count(); i++)
           {
               UserGroup usergroup = new UserGroup();
               usergroup.GroupID = id;
               usergroup.UserName = selectedUsers[i];
                   tms.UserGroups.Add(usergroup);
           }
        }
    }
