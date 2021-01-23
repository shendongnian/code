    public static HttpContext getCurrentSession()
      {
            HttpContext.Current = new HttpContext(new HttpRequest("", ConfigurationManager.AppSettings["UnitTestSessionURL"], ""), new HttpResponse(new System.IO.StringWriter()));
            System.Web.SessionState.SessionStateUtility.AddHttpSessionStateToContext(
            HttpContext.Current, new HttpSessionStateContainer("", new SessionStateItemCollection(), new HttpStaticObjectsCollection(), 20000, true,
            HttpCookieMode.UseCookies, SessionStateMode.InProc, false));
            return HttpContext.Current;
      }
