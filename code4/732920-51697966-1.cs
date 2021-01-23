    using System;
    using System.Data;
    using System.Web;
    using System.Web.Optimization;
    using System.Web.Routing;
    
    namespace YOURNAMESPACE
    {
    public class Global : HttpApplication
        {
            //1. Create a lock and a DataSet object.
            private static readonly Object lockObj = new object();
            private static DataSet dataSet = new DataSet();
            
            void Application_Start(object sender, EventArgs e)
            {
                // Code that runs on application startup
                
                //2. Read counter.xml into the dataSet any time the  
                //application is started. Here counter.xml is in the Application root.
                dataSet.ReadXml(Server.MapPath("~/counter.xml"));
               
                RouteConfig.RegisterRoutes(RouteTable.Routes);
                BundleConfig.RegisterBundles(BundleTable.Bundles);
            }
