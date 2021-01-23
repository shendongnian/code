    public class CheckSessionCharacterNameAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Session["CharacterName"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(...);
            }
        }
    }
