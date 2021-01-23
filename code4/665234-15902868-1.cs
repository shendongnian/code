    public ActionResult Login(string returnUrl)
    {
       ....
       var id = this.GetIdInReturnUrl(returnUrl);
       if (id != null) 
       {
       }
       ....
    }
    
    private int? GetIdInReturnUrl(string returnUrl) 
    {
       if (!string.IsNullOrWhiteSpace(returnUrl)) 
       {
           var returnUrlPart = returnUrl.Split('/');
           if (returnUrl.Length > 1) 
           {
               var value = returnUrl[returnUrl.Length - 1];
               int numberId;
               if (Int32.TryParse(value, out numberId))
               {
                   return numberId; 
               }
           }
       }
    
       return (int?)null;
    }
