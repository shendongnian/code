    using System.Web;
    using System.IdentityModel.Claims;
    using System.IdentityModel.Policy;
    
    namespace TicketingCore
    {
        public class HttpContextPrincipalPolicy : IAuthorizationPolicy
        {
            public bool Evaluate(EvaluationContext evaluationContext, ref object state)
            {
                HttpContext context = HttpContext.Current;
    
                if (context != null)
                {
                    evaluationContext.Properties["Principal"] = context.User;
                }
    
                return true;
            }
    
            public System.IdentityModel.Claims.ClaimSet Issuer
            {
                get { return ClaimSet.System; }
            }
    
            public string Id
            {
                get { return "TicketingCore HttpContextPrincipalPolicy"; }
            }
        }
    } 
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Claims;
    using System.IdentityModel.Policy;
    using System.Text;
    using System.Web;
    using System.Security.Principal;
    
    namespace TicketingCore
    {
        // syncs ServiceSecurityContext.PrimaryIdentity in WCF with whatever is set 
        // by the HTTP pipeline on Context.User.Identity (optional)
        public class HttpContextIdentityPolicy : IAuthorizationPolicy
        {
            public bool Evaluate(EvaluationContext evaluationContext, ref object state)
            {
                HttpContext context = HttpContext.Current;
    
                if (context != null)
                {
                    // set the identity (for PrimaryIdentity)
                    evaluationContext.Properties["Identities"] = 
                        new List<IIdentity>() { context.User.Identity };
    
                    // add a claim set containing the client name
                    Claim name = Claim.CreateNameClaim(context.User.Identity.Name);
                    ClaimSet set = new DefaultClaimSet(name);
                    evaluationContext.AddClaimSet(this, set);
                }
    
                return true;
            }
    
            public System.IdentityModel.Claims.ClaimSet Issuer
            {
                get { return ClaimSet.System; }
            }
    
            public string Id
            {
                get { return "TicketingCore HttpContextIdentityPolicy"; }
            }
        }
    }
    
