    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Security.Principal;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web;
    namespace BosIdentityManager
    {
    public class BosPrincipal
    {
        /// <summary>
        /// The current principal is set during FORMS authentication.  If WINDOWS auth mode is in use, Windows sets it.
        /// </summary>
        /// <returns> The Name from Thread.CurrentPrincipal.Identity.Name unless alternate delegate is configured</returns>  
        public static string GetCurrentUserName()
        {
        //   http://msdn.microsoft.com/en-us/library/system.security.claims.claimsprincipal.current   
        //  with forms auth and windows integrated,ClaimsPrincipal.Current will be set.
        
            var prin = ClaimsPrincipal.Current;  //normally this reverts to Thread.CurrentPrincipal, but can chnage !
            return prin.Identity.Name;
           
        }
        public static string GetCurrentWindowsUserName()
        {
            return WindowsIdentity.GetCurrent().Name;   
        }
        public static void SetPrincipal(BosMasterModel.Membership memb)
       {
           var claims = new List<Claim>(){ new Claim(ClaimTypes.Name, memb.SystemUser.UserName),
                                           new Claim(ClaimTypes.NameIdentifier,memb.UserId.ToString()),
                                           new Claim(ClaimTypes.Role, "SystemUser") };
           var ClaimsId = new ClaimsIdentity(claims,"Forms");
           var prin = new ClaimsPrincipal(ClaimsId);
           Thread.CurrentPrincipal = prin;
       }
    }
    }
