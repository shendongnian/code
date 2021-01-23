    bool lastNull = false;
    string eol = ((char)174).ToString();
    string[] docTextRaws = DocText.Split((char)174);
    string docTextRaw;
    for (Int32 j = 0; j < docTextRaws.Length; j++)
    {
        docTextRaw = docTextRaws[j].TrimEnd();
        if (string.IsNullOrEmpty(docTextRaw))
        {
            if (!lastNull)
            {
                docTextDownloadLines.Add(eol);
                lastNull = true;
            }
        }
        else
        {
            docTextDownloadLines.Add(docTextRaw + eol);
            if (lastNull) lastNull = false;
        }
    }
