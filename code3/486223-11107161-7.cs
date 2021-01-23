    [Authorize]
    public class AccountController : Controller
    {
        private readonly IMembershipService membershipService;
        // service initialization is handled by IoC container
        public AccountController(IMembershipService membershipService)
        {
            this.membershipService = membershipService;
        }
        // .. some other stuff ..
        [AllowAnonymous, HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (this.ModelSteate.IsValid)
            {
                var result = this.membershipService.CreateUser(
                    model.UserName, model.Password, model.Email, isApproved: true
                );
                if (result.Success)
                {
                    FormsAuthentication.SetAuthCookie(
                        result.Value.UserName, createPersistentCookie: false
                    );
                     
                    return this.RedirectToAction("Index", "Home");
                }
                result.Errors.CopyTo(this.ModelState);
            }
            
            return this.View();
        }
    }
