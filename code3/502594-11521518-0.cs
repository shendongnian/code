    <%@ PreviousPageType VirtualPath="~/SourcePage.aspx" %> 
    
    
    if(PreviousPage != null)
    {
        if(PreviousPage.IsCrossPagePostBack == true)
        {
                PeriodFrom.Value =PrevForm.TextBox.Text;
        }
    }
    else
    {
        PeriodFrom.Value = "Not a cross-page post.";
    }
