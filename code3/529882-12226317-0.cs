    public class CheckForAd : ActionFilterAttribute {
        public override void OnActionExecuted( ActionExecutedContext filterContext ) {
            var data = filterContext.HttpContext.Request.QueryString["AdName"];
            if( data != null ) {
                HttpCookie aCookie = new HttpCookie( "Url-Referrer" );
                aCookie.Value = data;
                aCookie.Expires = DateTime.Now.AddDays( 2 );
                filterContext.HttpContext.Response.Cookies.Add( aCookie );
            }
            base.OnActionExecuted( filterContext );
        }
    }
