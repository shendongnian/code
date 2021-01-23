    public class AjaxLinks
    {
        public List<LinkItem> LinkItems { get; set; }
        public AjaxOptions AjaxOptions { get; set; }
        public Dictionary<string, Object> HtmlAttrbs { get; set; }
        public AjaxLinks(AjaxOptions options, Dictionary<string, Object> htmlAttrbutes)
        {
            LinkItems = new List<LinkItem>();
            this.AjaxOptions = options;
            this.HtmlAttrbs = htmlAttrbutes;
        }
    }
    public class LinkItem
    {
        public string Text { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public LinkItem(string Text, string Controller, string Action)
        {
            this.Text = Text;
            this.Controller = Controller;
            this.Action = Action;
        }
    }
