    namespace MyApp.DataAccess
    {
        public class DB
        {
            public string cfg;
            public DB()
            {
                var asmName = System.Reflection.Assembly.GetAssembly(this.GetType()).GetName().Name;
                var asmPath = System.Web.HttpContext.Current.Server.MapPath(@"bin\" + asmName + ".dll");
                var cm = ConfigurationManager.OpenExeConfiguration(asmPath);
                this.cfg = cm.AppSettings.Settings["foo"].Value;
            }
        }
    }
