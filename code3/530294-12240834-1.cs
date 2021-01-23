    public static void UpdateUser(User user)
    {
          Save<User>(u => { 
             u.Attach(user); 
             u.Context.ObjectStateManager
                  .ChangeObjectState(user, System.Data.EntityState.Modified);
             });
    } 
