    public static bool IsWorkingCopy(string path)
    {
        using (var client = GetSvnClient())
        {
            var uri = client.GetUriFromWorkingCopy(path);
            return uri != null;
        }
    }
