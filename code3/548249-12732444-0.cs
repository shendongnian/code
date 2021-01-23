    public string[] getFilenameFromPath(string[] filePath)
        {
            char[] splitChar = new Char[]{'\\','\\'};
            for (int i = 0; i < filePath.Length; i++)
            {
                filePath[i] = filePath[i].Split(splitChar, StringSplitOptions.RemoveEmptyEntries).Last();
            }
            return filePath;
        }
