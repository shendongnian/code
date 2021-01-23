    ClientContext clientContext =
     new ClientContext(string.Format("http://{0}:{1}/", 
                                                server, 
                                                port)); 
    WebCollection webs = clientContext.Web.GetSubwebsForCurrentUser(null);
