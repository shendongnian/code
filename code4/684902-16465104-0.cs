      var roles = (WebMatrix.WebData.SimpleRoleProvider)Roles.Provider;
 
      if (!roles.RoleExists("Admin"))
      {
          roles.CreateRole("Admin");
      }
