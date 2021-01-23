    public abstract class CustomViewStartPage : System.Web.Mvc.ViewStartPage {
        public Helpers.InvariantHelper ConfigHelper { get; private set; }
        public CustomViewStartPage() : base() {
            ConfigHelper = new Helpers.InvariantHelper();
        }
    }
