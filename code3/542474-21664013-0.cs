    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Security;
    using Bencsharp.BL.Services;
    using Bencsharp.Mvc.Filters;
    using Bencsharp.Mvc.Models;
    
    namespace Bencsharp.Mvc.Controllers
    {
        [InitializeSimpleMembership]
        public class HomeController : Controller
        {
            // ...
        }
    }
