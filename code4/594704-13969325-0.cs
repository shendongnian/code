    public static string CleanDomainName(string url)
    {
        var uri = new Uri(url);
        // This only removes www.
        //return uri.Host.replace("www.", string.Empty);
        // This removes any subdomains
        var parts = uri.Host.Split('.');
        return string.Join(".", parts.Skip(parts.Length - 2));
    }
