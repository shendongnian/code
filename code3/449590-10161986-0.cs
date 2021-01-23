    public class AccountController : Controller
        {
            // LoginWithFaceBook
            // First Contact with FB - oauth?client_id ... redirect_uri = /Account/FacebookLinker 
            // according to a bug files on FB redirect_uri MUST BE SAME FOR both trips ( to get the 'code' then exchange the code for 'access_token'
            public ActionResult ConnectFaceBookAccount()
            {
                string APP_ID = HttpContext.Application["FacebookAppId"].ToString();
                string redirect_uri = HttpContext.Application["FacebookOAuthRedirect"].ToString();
                string state = HttpContext.Application["state_guid"].ToString();
                // in this View I simply link to this URL
                ViewBag.FaceBookOAuthUrl = "https://www.facebook.com/dialog/oauth?client_id=" + APP_ID + "&redirect_uri="+redirect_uri+"&state=" + state+"&display=popup";
                          
    
                return View();
            }
    
            // Account/FacebookLinker
            //  redirect_uri for both getting 'code' and exchanging for 'access_token'
            public ActionResult FacebookLinker()
            {
                if (!Request.IsAuthenticated)
                {
                    Response.Redirect("/Account/LogOn");
                }
                // Per FB DOC, Make sure 'state' var returned is same one you sent to reduce chance of Cross Site Forgery
                if (Request.QueryString["state"].ToString() == HttpContext.Application["state_guid"].ToString())
                {
                    try
                    {
    
                        string FBcode = Request.QueryString["code"].ToString();
                        string APP_ID = HttpContext.Application["FacebookAppId"].ToString();
                        string APP_SECRET = HttpContext.Application["FacebookAppSecret"].ToString();
                        string redirect_uri = HttpContext.Application["FacebookOAuthRedirect"].ToString();
    
    
                      string FBAccessUrl = "https://graph.facebook.com/oauth/access_token?client_id=" + APP_ID + "&redirect_uri=" + redirect_uri + "&client_secret=" + APP_SECRET + "&code=" + FBcode;
    
    
                    string accessToken = null;
                    // Send the request to exchange the code for access_token
                    var accessTokenRequest = System.Net.HttpWebRequest.Create(FBAccessUrl);
                    HttpWebResponse response = (HttpWebResponse) accessTokenRequest.GetResponse();
    
                     // handle response from FB 
                     // this will not be a url with params like the first request to get the 'code'
                    Encoding rEncoding = Encoding.GetEncoding(response.CharacterSet);
    
                    using(StreamReader sr = new StreamReader(response.GetResponseStream(),rEncoding))
                    {
                        // parse the response to get the value of the 'access_token'
                        accessToken = HttpUtility.ParseQueryString(sr.ReadToEnd()).Get("access_token"); 
                    }
                        //TODO
                        // Add to the accessToken for the Logged in User.Identity to a FBUSERS Model
                        // WHen someone Logs in Check to see if they are also in FB
                        // ON Login Page add option to login with FaceBook
    
                   
                      return View();
    
                    }
                    catch (Exception exp)
                    {
                        // try to get token failed
    
                    }
                }
                else
                {
                     // state var form FB did not match state var sent
    
                }
                return View();
            }
