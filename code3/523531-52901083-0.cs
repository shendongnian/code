    private void ClearOldConfigurations()
    {
        var level = ConfigurationUserLevel.PerUserRoamingAndLocal;
        var configuration = ConfigurationManager.OpenExeConfiguration(level);
        var configurationFilePath = configuration.FilePath;
        var routePieces = configurationFilePath.Split(Path.DirectorySeparatorChar);
        var toRetainFolder = string.Empty;
        var toClearFolder = string.Empty;
        for (int i = routePieces.Length - 1; i > 1; i--)
        {
            if (routePieces[i].ToLower() == "data")
            {
                toRetainFolder = string.Join(Path.DirectorySeparatorChar.ToString(), routePieces.Take(i));
                toClearFolder = string.Join(Path.DirectorySeparatorChar.ToString(), routePieces.Take(i - 1));
                break;
            }
        }
        if (string.IsNullOrWhiteSpace(toRetainFolder) || string.IsNullOrWhiteSpace(toClearFolder))
        {
            return;
        }
        foreach (var dir in Directory.GetDirectories(toClearFolder))
        {
            if (dir.ToLower().Trim() != toRetainFolder.ToLower().Trim())
            {
                try
                {
                    Directory.Delete(dir, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
