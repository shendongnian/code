    using System;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace SO
    {
        public partial class WebForm4 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (PageBody != null)
                {
                    PageBody.Attributes.Add("class", "myClass");
                }
            }
        }
    }
