    using System.Web.Mvc;
    using System.Web.Mvc.Html;
    
    class Example {    
    
        void Method()
        {
           HtmlHelper<TModel> Html = new HtmlHelper<TModel>();
           MvcHtmlString result = Html.DisplayFor(prop => Model.Prop);
        }
    }
