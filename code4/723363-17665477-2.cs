    public static class EnterpriseResourceHelper
    {
        /// <summary>
        /// Gets a customizable resource
        /// </summary>
        /// <param name="helper">htmlHelper</param>
        /// <param name="key">Key of the resource</param>
        /// <returns>Either enterprise customized resource or base resource for current culture.</returns>
        public static string EnterpriseResource(this HtmlHelper helper, string key)
        {
            return CustomEnterpriseResource.GetString(key);
        }
    }
