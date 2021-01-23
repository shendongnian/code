    using System;
    using System.Data;
    using System.Configuration;
    using System.Collections;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Web.UI.HtmlControls;
    
    namespace Q11456633WebApp
    {
        public partial class _Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!this.IsPostBack)
                {
                    this.ListofDatesDdlkr.DataSource = this.ListOfDate;
                    this.ListofDatesDdlkr.DataBind();
                }
            }
    
            private DateTime[] ListOfDate
            {
                get
                {
                    return new DateTime[]
                    {
                        new DateTime(2012, 7, 1),
                        new DateTime(2012, 7, 2),
                        new DateTime(2012, 7, 3),
                        new DateTime(2012, 7, 4),
                        new DateTime(2012, 7, 5),
                    };
                }
            }
    
            protected void ListofDatesDdlkr_SelectedIndexChanged(object sender, EventArgs e)
            {
                this.ClientScript.RegisterStartupScript(
                    this.GetType(), 
                    "show_type", 
                    String.Format(
                        "alert('Type of SelectedObject:{0}')", 
                        this
                            .ListofDatesDdlkr
                                .SelectedObject
                                    .GetType()
                                        .FullName), 
                        true);
            }
        }
    }
