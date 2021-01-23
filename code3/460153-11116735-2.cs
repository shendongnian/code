    using System;
    using System.Threading;
    using System.Web.UI;
    
    public partial class ASPxLoadingPanel_Example : Page {
    
        protected void Page_Load(object sender, EventArgs e) {
            if(IsCallback) {
                // Intentionally pauses server-side processing,
                // to demonstrate the Loading Panel functionality.
                Thread.Sleep(500);
            }
            LoadingPanel.ContainerElementID = ASPxCheckBox1.Checked ? "Panel" : "";
        }
    
    }
