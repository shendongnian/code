    public string Extension
    {
        get
        {
            int length = this.FullPath.Length;
            int startIndex = length;
            while (--startIndex >= 0)
            {
                char ch = this.FullPath[startIndex];
                if (ch == '.')
                {
                    return this.FullPath.Substring(startIndex, length - startIndex);
                }
                if (((ch == Path.DirectorySeparatorChar) || (ch == Path.AltDirectorySeparatorChar)) || (ch == Path.VolumeSeparatorChar))
                {
                    break;
                }
            }
            return string.Empty;
        }
    }
 
