    private static string GetURLSimplified(string url)
        {
            string separator = "))/";
            string callerURL = "";
            if (url.Length > 3)
            {
                int index = url.IndexOf(separator);
                callerURL = url.Substring(index + separator.Length);
            }
            // if homepage (if callerURL = "")
            callerURL = string.IsNullOrWhiteSpace(callerURL) ? "/" : callerURL;
            return callerURL;
        }
