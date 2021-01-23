    public class MyAuthorize : AuthorizeAttribute
    {
        private Usuario loggedUser;
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.RawUrl != "/Home/Login")
            {
                if (filterContext.HttpContext.Session["usuario"] != null)
                {
                    loggedUser = (Usuario) filterContext.HttpContext.Session["usuario"];
                    ViewBag.nomeUsuario = loggedUser.Nome;
                    ViewBag.idUsuario = loggedUser.Id;
                }
                else
                {
                    filterContext.Result = new RedirectResult("~/Home/Login");
                }
                base.OnAuthorization(filterContext);
            }
        }
    }
