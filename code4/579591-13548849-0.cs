    private static string GetSubDomain(Uri url)
        {
            try
            {
                string host = url.Host;
                if (host.Split('.').Length > 2)
                {
                    int firstIndex = host.IndexOf(".");
                    string subdomain = host.Substring(0, firstIndex);
                    return subdomain;
                }
            }
            catch
            {
            }
            return string.Empty;
        }
