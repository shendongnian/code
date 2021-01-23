    private static System.Uri ExtendURL(System.Uri baseURL, string relURL)
    {
        string[] parts = relURL.Split("?".ToCharArray(), 2);
        if (parts.Length < 1)
        {
            return null;
        }
        else if (parts.Length == 1)
        {
            // No query string included with the relative URL:
            return new System.Uri(baseURL,
                                  parts[0] + baseURL.Query);
        }
        else
        {
            // Query string included with the relative URL:
            return new System.Uri(baseURL,
                                  parts[0] + (String.IsNullOrWhiteSpace(baseURL.Query) ? "?" : baseURL.Query + "&") + parts[1]);
        }
    }
    
    ExtendURL(new System.Uri("http://example.com/?authtoken=0x0x0"),"rpc/import?method=overwrite&runhooks=true");
    // Result: http://example.com/rpc/import?authtoken=0x0x0&method=overwrite&runhooks=true
