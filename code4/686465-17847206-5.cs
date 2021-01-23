    public class app_aspnet_layout : System.Web.Mvc.WebViewPage
    {
  
      public Execute()
      {
        throw new NotImplementedException();
      }
      public void ExecutePageHierarchy(WebPageContext pageContext, 
                                       TextWriter writer)
      {
        writer.Write("<html>")
        writer.Write("<body>")
        var section = pageContext.SectionWriters["MySectionName"];
        section();
        pageContext.View.ExecutePageHierarchy(null, writer)
        writer.Write("</body>")
        writer.Write("</html>")
      }
    }
    public class app_aspnet_index : System.Web.Mvc.WebViewPage
    { 
      // generated from the _layout Definition
      private WebViewPage startPage = new app_aspnet_layout();
      public Execute()
      {
         WebPageContext pageContext = new WebPageContext();
         pageContext.View = this;
         pageContext.SectionWriters.Add("MySectionName", 
                                        this.Section_MySectionName);
         var writer = HttpContext.Current.Response.Stream.AsTextWriter();
         if (startPage != null)
         {
           startPage.ExecutePageHierarchy(pageContext, writer);
         }
         else
         {
           this.ExecutePageHierarchy(pageContext, writer);
         }
      }
      // html generated from non-section html
      public void ExecutePageHierarchy(WebPageContext pageContext, 
                                       TextWriter writer)
      {
        writer.Write("<div>My Body</div>");
      }
      public void Section_MySectionName(TextWriter writer)
      {
        writer.Write("<div>MySection</div>");
      }
    }
