    using (StreamReader sr = new StreamReader(renamedFile))
    using (StreamWriter sw = new StreamWriter(file.FullName, false))
    {
        string entityDeclaration = "foo";
        sw.Write(entityDeclaration);
        string strFileContents = string.Empty;
        int read;
        while ((read = sr.Read(buffer, 0, buffer.Length)) > 0)
        {
            sw.Write(buffer);
        }
    }
