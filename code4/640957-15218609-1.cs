         public void VerifyPermission()
        {
            var currentUser= SessionHelper.GetCurrentUser();
            var permissions = Utility.GetUserPermissions(currentUser.RoleId);
            
                this.CanView=permissions.Contains((int)this.pageView);
    
                this.CanEdit=permissions.Contains((int)this.pageEdit);
            
                this.CanDelete=permissions.Contains((int)this.pageDelete);
              
        }
