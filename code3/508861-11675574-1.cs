    namespace MyProject
    {
        public partial class CustomPage: System.Web.UI.Page
        {
             public CustomPage()
             {
                this.Init += new EventHandler(CustomPage_Init);
                this.Load += new EventHandler(CustomPage_Load);
                this.PreRender += new EventHandler(CustomPage_PreRender);
                this.Unload += new EventHandler(CustomPage_Unload);
             }
    
             protected void TangoWebPage_Load(object sender, EventArgs e)
             {
                //do stuff
             } 
    
         ...
        }
    }
