        async private void WebView_ScriptNotify(object sender, NotifyEventArgs e)
        {
            try
            {
                string data = e.Value;
                if (data.ToLower().StartsWith("launchlink:"))
                {
                    await Launcher.LaunchUriAsync(new Uri(data.Substring("launchlink:".Length), UriKind.Absolute));
                }
            }
            catch (Exception)
            {
                // Could not build a proper Uri. Abandon.
            }
        }
