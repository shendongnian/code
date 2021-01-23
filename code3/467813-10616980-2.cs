    String[] oldLines = File.ReadAllLines(path);
    List<String> newLines = new List<String>(oldLines.Length);
    foreach (String unmodifiedLine in oldLines)
    {
        String line = unmodifiedLine;
        int indexCommentStart = line.IndexOf("/*");
        int indexComment = line.IndexOf("--");
        while (indexCommentStart != -1 && (indexComment == -1 || indexComment > indexCommentStart))
        {
            int indexCommentEnd = line.IndexOf("*/", indexCommentStart);
            if (indexCommentEnd == -1)
                indexCommentEnd = line.Length - 1;
            else
                indexCommentEnd += "*/".Length;
            line = line.Remove(indexCommentStart, indexCommentEnd - indexCommentStart);
            indexCommentStart = line.IndexOf("/*");
        }
        indexComment = line.IndexOf("--");
        if (indexComment == -1)
            newLines.Add(line);
        else
            newLines.Add(line.Substring(0, indexComment));
    }
  
    File.WriteAllLines(path, newLines);
