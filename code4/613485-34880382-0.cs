    @using Microsoft.AspNet.Identity
    
    @if (Request.IsAuthenticated)
    {
        if (User.IsInRole("Administrator") || User.IsInRole("Moderator"))
        {
            ... Your code here
        }
    }
