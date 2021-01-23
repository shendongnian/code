    public static string FindRelativePath(string basePatrh, string targetPath){
           return  Uri.UnescapeDataString(
                basePatrh.MakeRelativeUri(targetPath)
                    .ToString()
                    .Replace('/', Path.DirectorySeparatorChar)
                );
    }
