    public class AccountController
    {
        private readonly IMembershipProvider _membershipProvider;
        public AccountController(IMembershipProvider membershipProvider)
        {
            this._membershipProvider = membershipProvider;
        }
        public ActionResult Register(RegistrationModel model)
        {
            // Try and catch this, returning a success ActionResult if it worked:
            this._membershipProvider.CreateUser(model.Email, model.Password);
        }
    }
