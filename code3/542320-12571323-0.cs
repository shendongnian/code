        public static MvcHtmlString MyActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName)
        {
            string actionLinkHtml = string.Format("<a href=\"/{0}/{1}\">{2}</a>", controllerName, actionName, linkText);
            return new MvcHtmlString(actionLinkHtml);
        }
