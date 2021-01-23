    var timeout = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["myTimeoutConfigSetting"]);    
    foreach (var cookey in Request.Cookies.AllKeys)
    {
      if (cookey == FormsAuthentication.FormsCookieName || cookey.ToLower() == "asp.net_sessionid")
      {
          var reqCookie = Request.Cookies[cookey];                                      
   
          if (reqCookie != null)
          {
              HttpCookie respCookie = new HttpCookie(reqCookie.Name, reqCookie.Value);
              respCookie.Expires = DateTime.Now.AddMinutes(timeout);
              Response.Cookies.Set(respCookie);
          }
      }
    }
