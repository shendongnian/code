    private string GetDomainName()
    {
        return HttpContext.Current.Session["DomainName"].ToString();
    }
    SqlConnection conn = null;
