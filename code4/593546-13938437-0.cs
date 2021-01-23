protected void Application_PreRequestHandlerExecute(object sender, EventArgs
e)
{
if(Request.Cookies["BetaResult"] == null)
{
   var  cookie = new HttpCookie("BetaResult");
   cookie.Expires = DateTime.Now.AddDays(1d);
   if(whatever logic to redirect to beta)
   {
       cookie["BetaResult"] = "Beta";
       Response.Cookies.Add(cookie);
       Response.Redirect("your beta site");
   }
   else
   {
       cookie["BetaResult"] = "Main";
       Response.Cookies.Add(cookie);
   }
  
}
else
{
  //if cookie value is beta, redirect to beta site, they 'are a chosen one'
}  
}
