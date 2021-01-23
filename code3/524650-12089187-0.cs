    private static readonly char[] InvalidfilenameCharacters = Path.GetInvalidFileNameChars();
    public static string SanitizeFileName(string filename)
    {
        return new string(
            filename
                .Where(x => !InvalidfilenameCharacters.Contains(x))
                .ToArray()
        );
    }
