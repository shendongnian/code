	public static MvcHtmlString ShowHidePartial(this HtmlHelper helper, string   partialName, TheUser user, string [] roles)
	{
                if(roles = null)
                {
                      return MvcHtmlString.Empty;
                }
		//If I don't know who you are or what you are trying to view        
		if(user != null && !string.IsNullOrEmpty(partialName) && user.Roles.Any(r=> roles.Contains(r)) )
		{
			return MvcHtmlString.Create(helper.Partial(partialName).ToString());
		}
		return  MvcHtmlString.Empty;
	}
