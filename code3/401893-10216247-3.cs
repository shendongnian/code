        public class AppSettings
    {
        /// <summary>
        /// Retrieves the value for "ImageBaseUrl" if the key exists
        /// </summary>
        /// <returns></returns>
        public static string GetImageBaseUrl()
        {
            string baseUrl = "";
            if (ConfigurationManager.AppSettings["ImageBaseUrl"] != null)
                baseUrl = ConfigurationManager.AppSettings["ImageBaseUrl"];
            return baseUrl;
        }
    }
