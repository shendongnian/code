    [HttpPost]
    public ActionResult Edit(UserRoleSaveVM saveRoles)
    { 
            
      if (saveRoles.UserNotInRoles != null)
      {                
         foreach (int roleID in saveRoles.UserNotInRoles)
         {
            //DO SOMETHING
                           
         }
      }
