    public partial class PopUp_TopicFilterControl : System.Web.UI.UserControl
    {
        public string TopicCategory
        {
            get { return TopicCategoryFilterList.SelectedValue.ToString(); }
        }
    }
