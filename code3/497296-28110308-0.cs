     // count users online on all desktopsites
            void Session_Start(object sender, EventArgs e)
            {
                try
                {
                    // lock application object
                    Application.Lock();
    
                    // get hashset containing all online ip adresses
                    var ips = (HashSet<string>)Application["visitors_online_list_ip"];
    
                    // get user ip
                    var ip = HttpContext.Current.Request.UserHostAddress;
    
                    // add ip to hashset
                    ips.Add(ip);
    
                    // store ip in session to delete when session ends
                    Session["ip"] = ip;
    
                    // save hashset
                    Application["visitors_online_list_ip"] = ips;
    
                    // unlock application object 
                    Application.UnLock();
                }
                catch {}
            }
    
            void Session_End(object sender, EventArgs e)
            {
                try
                {
                    // lock application object
                    Application.Lock();
    
                    // get hashset containing all online ip adresses
                    var ips = (HashSet<string>)Application["visitors_online_list_ip"];
    
                    // get user ip from Session because httpcontext doesn't exist
                    var ip = Session["ip"].ToString(); ;
    
                    // remove ip from hashset
                    ips.Remove(ip);
    
                    // save hashset
                    Application["visitors_online_list_ip"] = ips;
    
                    // unlock application object 
                    Application.UnLock();
                }
                catch {}
            }
