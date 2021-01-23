    public class WebPagePlus : WebPage
    {
        public HelperResult RenderZone(int zone) {
           return this.RenderPage("~/_RenderWidgets.cshtml", new {ZoneId = zone});
        }
    }
