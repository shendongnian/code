    public class AccountController
    {
        private readonly MembershipProvider _membershipProvider;
    
        public AccountController(MembershipProvider membershipProvider)
        {
            _membershipProvider = membershipProvider;
        }
    
        public ActionResult Register(RegistrationModel model)
        {
            MembershipCreateStatus result;
            _membershipProvider.CreateUser(model.Email, model.Password, ..., out result);
            
            return View(/*Make this depend on the result*/);
        }
    }
