    // on the Site.Master.cs
    public string CurrentPage;
    // on the page, inside the Page_Load event
    ((Site)this.Master).CurrentPage = 'My page';
    // on the Site.Master
    <%
    if (CurrentPage == "My page")
    {
        %>My page is loaded.<%
    }
    else
    {
        %>Another page is loaded.<%
    }
    
