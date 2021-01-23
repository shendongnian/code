    using System.Web.UI; // for Page
    using System.Web; //for HttpContext
    
    Page page = HttpContext.Current.CurrentHandler as Page;
    page.ClientScript.RegisterStartupScript(typeof(Page), "key", "<script>voteTab();</script>");
