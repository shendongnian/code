    using System.Web.Optimization;
    using SitePessoal.Web;
    
    namespace SitePessoal.Web.Application
    {
        public class Global : HttpApplication
        {
            private void Application_Start(object sender, EventArgs e)
            {
		          BundleConfig.RegisterBundles(BundleTable.Bundles);
                  BundleTable.EnableOptimizations = true;
            }
        }
    }
