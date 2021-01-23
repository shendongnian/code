    public static MvcHtmlString CreateMenuItems(this UrlHelper url, string action, string text)
    {
         var menuItem = new TagBuilder("li");
         var link = new TagBuilder("a");
    
         //Get current action from route data
         var currentAction = (string)helper.RequestContext.RouteData.Values["action"];
         link.Attributes.Add("href", url.Action(action, "home", new { title = "whatever" }));
    
         if (currentAction == action)
         {
             menuItem.AddCssClass("selected");
         }
    
         link.SetInnerText(text);
         menuItem.InnerHtml = link.ToString();
    
         return MvcHtmlString.Create(menuItem.ToString());
     }
