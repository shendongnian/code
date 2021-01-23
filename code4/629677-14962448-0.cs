    foreach (string removePath in Verifier.ExcludePaths)
    {
        try
        {
            // Remove files and directories to be excluded
            zipFile.RemoveEntry(removePath);
        }
        catch (Exception)
        {
            Logger.Warn("Could not exclude path \"{0}\".",removePath);
        }
    }
