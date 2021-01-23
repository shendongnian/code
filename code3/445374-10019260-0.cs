    if (item.ID.Length > 0)
    {
    	string URLOfPic; 
    	if(item.ID > 1000) 
    	{     
    		URLOfPic="~/images/aaa.png";
    	} else {     
    		URLOfPic="~/images/bbb.png";
    	}
    	return Html.Raw(string.Format("<text><img src=\"{0}\" alt=\"Image\" class=\"ToolTip\" title=\"ID # {1} <br> \" /></text>", Url.Content(URLOfPic), @item.ID.ToString()));                 
    } 
