    void Session_Start(object sender, EventArgs e) 
        {
            System.Collections.Generic.Dictionary<string, DateTime> Visitors =
                                new System.Collections.Generic.Dictionary<string, DateTime>();
            Visitors.Add(Session.SessionID, DateTime.Now);        
            HttpContext.Current.Application.Lock();
            Application["Visitors"] = Visitors;
            HttpContext.Current.Application.UnLock();
        }
