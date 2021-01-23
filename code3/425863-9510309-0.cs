    using System.Linq;
    protected void BindGridview() 
    { 
       var users = from user in Membership.GetAllUsers()
                        where user.UserType != "Admin"
                        select user;
       gvDetails.DataSource = users; 
       
       gvDetails.DataBind(); 
    } 
