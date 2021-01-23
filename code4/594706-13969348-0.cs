    /// <summary>
    /// Clears the sub domains from a URL.
    /// </summary>
    /// <param name="url">The URL.</param>
    /// <returns>String for a URL without any subdomains</returns>
    private static string ClearUrlSubDomains(Uri url)
    {
    	var host = url.Host.ToLowerInvariant();
    	if (host.LastIndexOf('.') != host.IndexOf('.'))
    	{
    		host = host.Remove(0, host.IndexOf('.') + 1); // Strip out the subdomain (i.e. remove en-gb or www etc)
    	}
    	return host;
    }
