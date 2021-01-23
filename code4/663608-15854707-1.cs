    bool isLoggedIn = false;
    xmpp.OnLogin += (sender) => { isLoggedIn = true; };
    xmpp.Open(jidSender.User, Password);
    
    while (isLoggedIn == false) 
    { 
        System.Threading.Thread.Sleep(100); 
    }
    
    Presence p = new Presence(ShowType.chat, "Online");
    p.Type = PresenceType.available;
    xmpp.Send(p);
