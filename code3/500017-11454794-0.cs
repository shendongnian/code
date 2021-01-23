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
    
    namespace Q11454649WebApp
    {
        public partial class _Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!this.IsPostBack)
                {
                    ObjectDataSource d = new ObjectDataSource();
                    d.ID = "s";
                    d.SelectMethod = "GetAllUsers";
                    //d.TypeName = SPGridView.GetType().AssemblyQualifiedName;
                    d.TypeName = this.GetType().AssemblyQualifiedName;
                    this.Controls.Add(d);
                    /// Apply a data source to the SPGrid View
                    SPGridView.DataSourceID = d.ID;
                }
            }
    
            [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
            public string[] GetAllUsers()
            {
                return new string[] { "Joe", "Alan", "Michel" };
            }
        }                              
    }
