    public static string GetFileName(string path)
    {
        if (path != null)
        {
            CheckInvalidPathChars(path);
            int length = path.Length;
            int num2 = length;
            while (--num2 >= 0)
            {
                char ch = path[num2];
                if (((ch == DirectorySeparatorChar) || 
                    (ch == AltDirectorySeparatorChar)) || 
                    (ch == VolumeSeparatorChar))
                {
                    return path.Substring(num2 + 1, (length - num2) - 1);
                }
            }
        }
        return path;
    }
 
