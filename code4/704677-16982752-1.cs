    public class MyPage: System.Web.UI.Page
    {
        public System.Web.UI.WebControls.ContentPlaceHolder GetMyContentPlaceHolder()
        {
            System.Web.UI.WebControls.ContentPlaceHolder holder = null;
            Site1 site = this.Master as Site1;
            if (site != null)
            {
                holder = site.FindControl("ContentPlaceHolder1") as System.Web.UI.WebControls.ContentPlaceHolder;
            }
            return holder;
        }
    }
