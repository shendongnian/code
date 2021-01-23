     Configuration config;
 
            if (System.Web.HttpContext.Current != null &&
                System.Web.HttpContext.Current.Request.PhysicalPath.Equals(String.Empty) == false)
            {
                config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
            }
            else
            {
                config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            }
