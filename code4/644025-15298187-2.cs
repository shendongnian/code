    @model int
    @functions {
        IDictionary<string, object> GetHtmlAttributes(int i) {
            var routeData = ViewContext.ParentActionViewContext.RouteData;
            int currentPage = 0;
            string page = routeData.Values["page"] as string;
            var htmlAttributes = new RouteValueDictionary();
            if (int.TryParse(page, out currentPage) && currentPage == i)
            {
                htmlAttributes["class"] = "active";
            }
            return htmlAttributes;
        }
    }
    
    <ul id="pages">
        @for (var i = 1; i <= Model; i++) 
        {
            <li>
                @Html.ActionLink(
                    "Page " + i,
                    "Page", 
                    "Service", 
                    new RouteValueDictionary(new { page = i }), 
                    GetHtmlAttributes(i)
                )
            </li>
        }
    </ul>
