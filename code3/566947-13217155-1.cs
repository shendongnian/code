        /// <summary>
        /// Opens new window
        /// </summary>
        /// <param name="page"></param>
        /// <param name="fullUrl"></param>
        public static void OpenNewWindow(System.Web.UI.Page page, string fullUrl, string key)
        {
            string script = "window.open('" + fullUrl + "', 'a', 'status=1,location=1,menubar=1,resizable=1,toolbar=1,scrollbars=1,titlebar=1');";
            page.ClientScript.RegisterClientScriptBlock(page.GetType(), key, script, true);
        }
