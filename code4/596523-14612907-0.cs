        /// <summary>
        /// Custom Policy Violation Handler. See http://www.fluentsecurity.net/wiki/Policy-violation-handlers
        /// </summary>
        public class DenyAnonymousAccessPolicyViolationHandler : IPolicyViolationHandler
        {
            public ActionResult Handle(PolicyViolationException exception)
            {
                Flash.Error("You must first login to access that page");
                return new RedirectResult("/");
            }
        }
