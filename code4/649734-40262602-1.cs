    public static MvcHtmlString RenderListTag(this HtmlHelper helper, string labelText, string action, string controller, bool isAdmin, string listCssClass = "")
    {
        string value = string.Empty;
    
        TagBuilder li = new TagBuilder("li");
        TagBuilder anchor = new TagBuilder("a");
        UrlHelper urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
    
        if (string.IsNullOrEmpty(action) || string.IsNullOrEmpty(controller))
        {
            anchor.MergeAttribute("href", "#");
        }
        else
        {
            anchor.MergeAttribute("href", urlHelper.Action(action, controller, new
            {
                area = isAdmin ? "Admin" : ""
            }));
        }
    
        anchor.SetInnerText(labelText);
    
        if (action.IsEqualWith(helper.ViewContext.RouteData.Values["action"].ToString()))
        {
            li.MergeAttribute("class", "active");
        }
    
        if (!string.IsNullOrEmpty(listCssClass))
        {
            li.MergeAttribute("class", listCssClass);
        }
    
        li.SetInnerText(anchor.ToString(TagRenderMode.Normal));
    
        return new MvcHtmlString(li.ToString(TagRenderMode.Normal));
    }
