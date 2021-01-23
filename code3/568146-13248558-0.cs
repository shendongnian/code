    public class BasePage : Page
    {
            
                protected string mySessionId;   
            
                private CurrentUser _currentUser;
                public CurrentUser _CurrentUser
                {
                    get { return ((CurrentUser)HttpContext.Current.Session["myCurrentUser"]); }
                    set { _currentUser = value; }
                }
            
            
                protected override void OnLoad(EventArgs e)
                {
                       
                    if (Session["myCurrentUser"] != null)
                    {
                        if (_CurrentUser.ProUser)
                        {
                            
                           mySessionId = Session.SessionID; // it means New Session
            
                        }
            
                        if (!mySessionId.IsNullOrDefault() && mySessionId != Session.SessionID)
                        {
                            Session.Abandon(); //Abandon current session and start new one                
            
                        }
                    }
            
            
                }
    
    }
     
