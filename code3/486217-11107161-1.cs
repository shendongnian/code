    public class AccountController : Controller
    {
        private readonly IMembershipService membershipService;
        // service initialization is handled by IoC container
        public AccountController(IMembershipService membershipService)
        {
            this.membershipService = membershipService;
        }
        // .. some other stuff ..
        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (this.ModelSteate.IsValid)
            {
                // translates view model into an entity model
                var user = new User { ... };
                // then passes it to the service method and checks for errors
                var result = this.membershipService.CreateUser(user);
                if (result.Success)
                {
                    return RedirectToAction(...);
                }
                result.Errors.CopyTo(this.ModelState);
            }
            
            return View();
        }
    }
