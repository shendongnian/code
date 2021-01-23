    public class Utilities
    {
        /// <summary>
        /// This will return the first parent of the control that is an update panel
        /// </summary>
        /// <param name="source">The source control</param>
        /// <returns>The first parent found for the control. Null otherwise</returns>
        public static UpdatePanel GetFirstParentUpdatePanel(Control source)
        {
            Page currentPage = source.Page;
            UpdatePanel updatePanel = null;
            Type updatePanelType = typeof(UpdatePanel);
            object test = source.Parent;
            while (test != null && test != currentPage)
            {
                // is this an update panel
                if (test.GetType().FullName == updatePanelType.FullName)
                {
                    // we've found the containing UpdatePanel
                    updatePanel = (UpdatePanel)test;
                }
                // check the next parent
                test = ((Control)test).Parent;
            } // next test
            return updatePanel;
        }
        /// <summary>
        /// This will open the specified url in a new window by injecting a small script in
        /// the current page that is run when the page is sent to the client's browser.
        /// This method accounts for the presence of update panels and script managers on the
        /// page that the control resides in.
        /// </summary>
        /// <param name="source">The control that the call is being made from</param>
        /// <param name="url">The URL to bring up in a new window</param>
        public static void RedirectToNewWindow(Control source, string url)
        {
            // create the script to register
            string scriptKey = "_NewWindow";
            string script = "window.open('" + url + "');";
            RegisterControlScript(source, scriptKey, script);
        }
        /// <summary>
        /// This will register a script for a specific control accounting for the control's UpdatePanel
        /// and whether or not there is a script manager on the page
        /// </summary>
        /// <param name="source">The control that will be affected by the script</param>
        /// <param name="scriptKey">A unique key for the script</param>
        /// <param name="script">The script that will affect the control</param>
        public static void RegisterControlScript(Control source, string scriptKey, string script)
        {
            // get the control's page
            Page currentPage = source.Page;
            // does the control reside in an UpdatePanel
            UpdatePanel updatePanel = GetFirstParentUpdatePanel(source);
            // did we find the UpdatePanel
            if (updatePanel == null)
            {
                // register the script on the page (works outside the control being in an update panel)
                currentPage.ClientScript.RegisterStartupScript(currentPage.GetType(), scriptKey,
                                                               script, true /*addScriptTags*/);
            }
            else
            {
                // register the script with the UpdatePanel and ScriptManger
                ScriptManager.RegisterClientScriptBlock(source, source.GetType(), scriptKey,
                                                        script, true /*addScriptTags*/);
            } // did we find the UpdatePanel
        }
    }
