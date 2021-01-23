    /// <summary>
    ///     Opens a local file or url in the default web browser.
    ///     Can be used both for opening urls, or html readme docs.
    /// </summary>
    /// <param name="pathOrUrl">Path of the local file or url</param>
    public static void OpenInDefaultBrowser(String pathOrUrl)
    {
        // Trim any surrounding quotes.
        pathOrUrl = pathOrUrl.Trim('"').Trim();
        // Default protocol to "http"
        String protocol = Uri.UriSchemeHttp;
        // Correct the protocol to that in the actual url
        if (Regex.IsMatch(pathOrUrl, "^[a-z]+" + Regex.Escape(Uri.SchemeDelimiter), RegexOptions.IgnoreCase))
        {
            Int32 schemeEnd = pathOrUrl.IndexOf(Uri.SchemeDelimiter, StringComparison.Ordinal);
            if (schemeEnd > -1)
                protocol = pathOrUrl.Substring(0, schemeEnd).ToLowerInvariant();
        }
        // Surround with quotes
        pathOrUrl = "\"" + pathOrUrl + "\"";
        // Get default browser from registry
        Object fetchedVal;
        String defBrowser = null;
        // Current method
        using (RegistryKey userDefBrowserKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\Shell\Associations\UrlAssociations\" + protocol + @"\UserChoice"))
        {
            if (userDefBrowserKey != null && (fetchedVal = userDefBrowserKey.GetValue("Progid")) != null)
            {
                using (RegistryKey pathKey = Registry.ClassesRoot.OpenSubKey(fetchedVal + @"\shell\open\command"))
                {
                    if (pathKey != null && (fetchedVal = pathKey.GetValue(null)) != null)
                        defBrowser = fetchedVal as String;
                }
            }
        }
        // Fallback method
        if (defBrowser == null)
        {
            using (RegistryKey defBrowserKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Classes\" + protocol + @"\shell\open\command"))
            {
                if (defBrowserKey != null && (fetchedVal = defBrowserKey.GetValue(null)) != null)
                    defBrowser = fetchedVal as String;
            }
            if (defBrowser == null)
            {
                using (RegistryKey defBrowserKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Classes\" + protocol + @"\shell\open\command"))
                {
                    if (defBrowserKey != null && (fetchedVal = defBrowserKey.GetValue(null)) != null)
                        defBrowser = fetchedVal as String;
                }
            }
            if (defBrowser == null)
            {
                using (RegistryKey defBrowserKey = Registry.ClassesRoot.OpenSubKey(protocol + @"\shell\open\command"))
                {
                    if (defBrowserKey != null && (fetchedVal = defBrowserKey.GetValue(null)) != null)
                        defBrowser = fetchedVal as String;
                }
            }
        }
        // Nothing found. Return.
        if (String.IsNullOrEmpty(defBrowser))
            return;
        String defBrowserProcess;
        String defBrowserArgs;
        // Parse browser parameters. This code first assembles the full command line, and then splits it into the program and its parameters.
        if (defBrowser.Contains("%1"))
        {
            // If url in the command line is surrounded by quotes, ignore those; our url already has quotes.
            if (defBrowser.Contains("\"%1\""))
                defBrowser = defBrowser.Replace("\"%1\"", pathOrUrl);
            else
                defBrowser = defBrowser.Replace("%1", pathOrUrl);
            if (defBrowser[0] == '"')
                defBrowserProcess = defBrowser.Substring(0, defBrowser.Substring(1).IndexOf('"') + 2).Trim();
            else
                defBrowserProcess = defBrowser.Substring(0, defBrowser.IndexOf(" ", StringComparison.Ordinal)).Trim();
            defBrowserArgs = defBrowser.Substring(defBrowserProcess.Length).TrimStart();
        }
        else
        {
            defBrowserProcess = defBrowser;
            defBrowserArgs = pathOrUrl;
        }
        // Run the process.
        if (new FileInfo(defBrowserProcess.Trim('"')).Exists)
            Process.Start(defBrowserProcess, defBrowserArgs);
    }
