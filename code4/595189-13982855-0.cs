    public partial class FrontPageBox1 : BlogEngine.Core.Web.Controls.PostViewBase
    {
        protected override void OnInit(EventArgs e)
        {
            Guid itemID = new Guid("6b64de49-ecab-4fff-9c9a-242461e473bf");
            BlogEngine.Core.Page thePage = BlogEngine.Core.Page.GetPage(itemID);
            if( thePage != null )
                box1.InnerHtml = thePage.Content;
            else
                box1.InnerHtml = "<h1>Page was NULL</h1>";
        }
    }
