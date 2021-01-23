    public static string GetMode(string fileOrExt)
    {
        string ext = System.IO.Path.GetExtension(fileOrExt);
        if (ext == String.Empty) {
            ext = fileOrExt;
            if (!ext.StartsWith(".")) {
                ext = "." + ext;
            }
        }
        Info info;
        if (mimedictionary.TryGetValue(ext, out info)) {
            return info.Mode;
        }
        return "-";
    }
