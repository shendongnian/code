    public partial class Search_Master : System.Web.UI.MasterPage
    {
        public enum ContentViews
        {
            vw100 = Content_Master.ContentViews.vw100,
            vw3070 = Content_Master.ContentViews.vw3070,
            vw7030 = Content_Master.ContentViews.vw7030
        }
        public ContentViews CurrentView
        {
            get 
            {
                MultiView mvwDisplay;
                mvwDisplay = (MultiView)Master.FindControl("mvwDisplay");
                return ((ContentViews)mvwDisplay.ActiveViewIndex); 
            }
            set 
            {
                MultiView mvwDisplay;
                mvwDisplay = (MultiView)Master.FindControl("mvwDisplay");
                mvwDisplay.ActiveViewIndex = (int)value; 
            }
        }
    }
