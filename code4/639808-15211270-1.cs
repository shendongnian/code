     public YourController:Controller
     {
         private IMembershipService  _membership 
         public YourController(IMembershipService membership)
         {
             _membership = membership;
         } 
      
         public ViewResult Index(int? index)
         {
           if (Roles.IsUserInRole("Group Admin"))
           {
               string[] roles = Roles.GetRolesForUser();
           
               var GroupUsers = _membership.UsersInGroup();
