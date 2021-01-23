    public partial class NewsArticleContainer : System.Web.UI.UserControl
    {
       List<string> NewsArticle = null;
       public NewsArticleContainer(List<string> toCreateNewsArticle)
       {
          NewsArticle = toCreateNewsArticle;
       }
      
        protected void Page_Load(object sender, EventArgs e)
        {
           foreach(string s in NewsArticle)
           {
              //dynamically create your label control and add it to this user control
           }
        }
    }
