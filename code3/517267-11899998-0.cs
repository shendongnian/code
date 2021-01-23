    using System.Web;
    using System.Web.UI;
    ...
    var page = HttpContext.Current.CurrentHandler as Page;
    if( page == null ){
         // throw an exception, something bad happened
    }
    // now you have access to the current page...
    page.ClientScript.RegisterStartupScript();
