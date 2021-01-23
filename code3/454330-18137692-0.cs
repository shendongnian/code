    /// <summary>
    /// This method seems a bit complicated for fetching a file's path,
    /// but it's flexible enough to fetch a path for both console 
    /// applications and service applications.
    /// </summary>
    /// <param name="relativePath">Relative path to a resource.</param>
    /// <returns>Absolute path.</returns>
    private string GetAppAbsolutePath(string relativePath)
    {
        return Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), relativePath);
    }
