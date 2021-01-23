    void Application_BeginRequest(object sender, EventArgs e) 
    {
        //if user is changing language
        if(!String.IsNullOrEmpty(HttpContext.Current.Request["lang"]))
        {
            String sLang =  HttpContext.Current.Request["lang"] as String;
            //change the language of the application to the chosen
            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(sLang);
            //save it to cookie
            HttpCookie myCookie = new HttpCookie("Language"); 
            myCookie.Value = sLang;
            myCookie.Expires = DateTime.Now.AddDays(1d);
            HttpContext.Current.Response.Cookies.Add(myCookie);
        }
        //setting as been preserved in cookie
        else if(HttpContext.Current.Request.Cookies["Language"])
        {
            //change the language of the application to the preserved
            String sLang =  HttpContext.Current.Request.Cookies["lang"].value as String;
            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(sLang);
        }
        else//new visit
        {
            //change the language of the application to the default
            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-us");
            //set cookie to the default
            HttpCookie myCookie = new HttpCookie("Language"); 
            myCookie.Value = "en-us";
            myCookie.Expires = DateTime.Now.AddDays(1d);
            HttpContext.Current.Response.Cookies.Add(myCookie);
        }
    }
