    @using HtmlHelper=System.Web.Mvc.HtmlHelper
    @using System.Web.Mvc.Html
    
    @helper Item(HtmlHelper html, string action, string htmlClass)
    {
        <section class="@htmlClass">
            @{ html.RenderAction(action); }
        </section>
    }
    @helper Item(HtmlHelper html, string action, string htmlClass, bool test)
    {
        if (test)
        {
            @Item(html, action, htmlClass)
        }
    }
