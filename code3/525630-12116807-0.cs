     HttpCookie currentUserCookie = HttpContext.Current.Request.Cookies["currentUser"];
     HttpContext.Current.Response.Cookies.Remove("currentUser");
     currentUserCookie.Expires = DateTime.Now.AddDays(-10);
     currentUserCookie.Value = null;
     HttpContext.Current.Response.SetCookie(currentUserCookie);
