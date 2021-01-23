    /// <summary>
    ///   Replaces invalid characters in a file name by " ". Apply only to the filename.ext
    ///   part, not to the path part.
    /// </summary>
    /// <param name="fileName">A file name (not containing the path part) possibly
    ///   containing invalid characters.</param>
    /// <returns>A valid file name.</returns>
    public static string GetValidFileName(string fileName)
    {
        string invalidChars = Regex.Escape(new string(Path.GetInvalidFileNameChars()));
        string s = Regex.Replace(fileName, "[" + invalidChars + "]", " ");
        s = Regex.Replace(s, @"\s\s+", " "); // Replace multiple spaces by one space.
        string fil = Path.GetFileNameWithoutExtension(s).Trim().Trim('.');
        string ext = Path.GetExtension(s).Trim().Trim('.');
        if (ext != "") {
            fil += "." + ext;
        }
        fil = fil.Replace(" .", ".");
        return fil == "." ? "" : fil;
    }
