    private void ReadContent(string path)
    {
        Contract.Requires<FileMissingException>(File.Exists(path));
        string content = filehelperobj.GetContent(path);
        m_xmlobj = content;
    }
