    private string GetDomain(string url)
        {
            string[] split = url.Split('.');
            if (split.Length > 2)
                return split[split.Length - 2] + "." + split[split.Length - 1];
            else
                return url;
        }
