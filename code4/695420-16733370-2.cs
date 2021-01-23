    string GetKey(){
    
          if (String.IsNullOrEmpty(HttpContext.Current.Session["mySessionKey"].ToString()))
                    HttpContext.Current.Session["mySessionKey"] = GenereteKey();
          return HttpContext.Current.Session["mySessionKey"].ToString();
    
    }
