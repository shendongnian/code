    // Summary:
    //     Returns the extension of the specified path string.
    //
    // Parameters:
    //   path:
    //     The path string from which to get the extension.
    //
    // Returns:
    //     A System.String containing the extension of the specified path (including
    //     the "."), null, or System.String.Empty. If path is null, GetExtension returns
    //     null. If path does not have extension information, GetExtension returns Empty.
    //
    // Exceptions:
    //   System.ArgumentException:
    //     path contains one or more of the invalid characters defined in System.IO.Path.GetInvalidPathChars().
    public static string GetExtension(string path);
