    PagedDataSource ds = new PagedDataSource();
    ds.DataSource = [YOUR DATA SOURCE];
    ds.AllowPaging = true;
    ds.PageSize = 10;
    ds.CurrentPageIndex = pageNo ?? 0;
    
    pnlPaging.Controls.Clear();
    for (int i = 0; i < ds.PageCount; i++)
    {
    	if (ds.PageCount < 2)
    	{
    		break;
    	}
    
    	if (pageNo == i || (pageNo == null && i == 0))
    	{
    		pnlPaging.Controls.Add(new LiteralControl("<span style=\"display:inline-block;margin:0 2px 2px 0;\">" + (i + 1).ToString() + "</span>"));
    		continue;
    	}
    
    	SuprLinkButton lb = new SuprLinkButton()
    	{
    		CommandName = "pageThis",
    		CommandArgument = i.ToString(),
    		ID = "lbPage" + i.ToString(),
    		Text = (i + 1).ToString()
    	};
    	lb.Attributes.Add("style", "display:inline-block;margin:0 2px 2px 0;");
    	lb.Command += new CommandEventHandler(lb_Command);
    	pnlPaging.Controls.Add(lb);
    }
    
    LISTVIEW.DataSource = ds;
    LISTVIEW.DataBind();
