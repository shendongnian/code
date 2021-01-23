    public partial class Products : System.Web.UI.Page
     {
         protected void Page_Load(object sender, EventArgs e)
         {
             GhostForm mainForm = new GhostForm();
             mainForm.RenderFormTag = false;
             .....     
         }
             // Send your data to PayPal :-)
         .....
     }
