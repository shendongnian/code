    if (System.Web.HttpContext.Current.Session["cookie"] != null)
                _cookies = System.Web.HttpContext.Current.Session["cookie"].ToString(); 
         using (WebClient wc =  new WebClient())
            {
              
                wc.Headers.Add("Cookie", _cookies);
                 string HtmlResult = wc.UploadString(bridge_url, myParameters);
                _cookies = wc.ResponseHeaders["Set-Cookie"];
                Debug.WriteLine("Headers" + _cookies); 
                System.Web.HttpContext.Current.Session["cookie"] = _cookies;
          
            } 
