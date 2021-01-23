    public override RouteData GetRouteData(HttpContextBase httpContext)
                {
                    var host = httpContext.Request.Headers["HOST"];
                    var url = httpContext.Request.RawUrl;
                    Regex regex = new Regex("/");
                    string[] substrings = regex.Split(url);
                    if (substrings.Length >= 3)
                    {
                        return null;
                    }
                    var index = host.IndexOf(".");
                    if (index < 0)
                    {
                        return null;
                    }
        
                    var subDomain = host.Substring(0, index);
        
                    if (subDomain != "www" && subDomain != "m")
                    {
                        var routeData = new RouteData(this, new MvcRouteHandler());
                            routeData.Values.Add("controller", "Business"); //Goes to the User1Controller class
                            routeData.Values.Add("action", "Display"); //Goes to the Index action on the User1Controller
                            routeData.Values.Add("id", subDomain);
                        return routeData;
                    }
        
                    if (subDomain == "m")
                    {
                        var routeData = new RouteData(this, new MvcRouteHandler());
                        routeData.Values.Add("controller", "Mobile"); //Goes to the User2Controller class
                        routeData.Values.Add("action", "Index"); //Goes to the Index action on the User2Controller
        
                        return routeData;
                    }
                    return null;
                }
