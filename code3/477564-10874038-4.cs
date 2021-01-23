    public abstract class MyViewStart : System.Web.Mvc.ViewStartPage {
        public My.Helpers.ThemeHelper Themes { get; private set; }
    
        public MyViewStart()
        {
            
        }
        public override void ExecutePageHierarchy()
        {
            this.Themes = new Helpers.ThemeHelper(this.ViewContext);;
            base.ExecutePageHierarchy();
        }
    }
