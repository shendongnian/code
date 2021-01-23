    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Security;
    
    using System.Text;
    using System.Data;
    using System.Data.SqlClient;
    
    namespace ENTER_YOUR_NAMESPACE
    {
        public class Global : System.Web.HttpApplication
        {
            void Application_Start(object sender, EventArgs e)
            {
    
            }
    
            void Application_End(object sender, EventArgs e)
            {
                /* Code that runs on application shutdown */
                Session_End(sender, e);
            }
    
            void Application_Error(object sender, EventArgs e)
            {
                
            }
    
            void Session_Start(object sender, EventArgs e)
            {
                
            }//end void Session_Start
    
            void Session_End(object sender, EventArgs e)
            {
                
            }//end void Session_End
    
        }//end class Global
    }//end namespace
