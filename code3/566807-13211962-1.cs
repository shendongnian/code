    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace WebApplication1
    {
        public class basepage : System.Web.UI.Page
        {
            protected int GetItem()
            {
                return Convert.ToInt32(Session["myvalue"]);
            }
        }
    }
