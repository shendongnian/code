    public static bool IsPathRooted(string path)
    {
        if (path != null)
        {
            Path.CheckInvalidPathChars(path);
            int length = path.Length;
            if ((length >= 1 && (path[0] == Path.DirectorySeparatorChar || path[0] == Path.AltDirectorySeparatorChar))
                || (length >= 2 && path[1] == Path.VolumeSeparatorChar))
            {
                return true;
            }
        }
        return false;
    }
