    public static string FindRelativePath(string basePath, string targetPath)
    {
               return Uri.UnescapeDataString(
                    basePath.MakeRelativeUri(targetPath)
                        .ToString()
                        .Replace('/', Path.DirectorySeparatorChar)
                    );
    }
