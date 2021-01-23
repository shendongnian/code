    public class BaseController : Controller
    {
     public DrOkUser GetCurrentUser()
        {
            if (!HttpContext.User.Identity.IsAuthenticated) return null;
            DrOkUser user = null;
            var guid = (Guid)Membership.GetUser().ProviderUserKey;
            if (HttpContext.User.IsInRole("Client"))
                 user = ClientManager.GetClient(guid);
            if (HttpContext.User.IsInRole("Supplier"))
                user = SupplierManager.GetSupplier(guid);
        
            user.Email = Membership.GetUser().Email;            
            return user;
        }
}
