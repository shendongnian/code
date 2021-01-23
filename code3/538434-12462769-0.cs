        UserPrincipal user = this is your user;
        GroupPrincipal group = this is your group;
        // this is fast
        using ( DirectoryEntry groupEntry = group.GetUnderlyingObject() as DirectoryEntry )
        using ( DirectoryEntry userEntry = user.GetUnderlyingObject() as DirectoryEntry )
        {         
          groupEntry.Invoke( "Add", new object[] { userEntry.Path } ); 
        }
        //group.Members.Add(user); // and this is slow!
        //group.Save();
