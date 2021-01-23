    String s1;
    using (StreamReader r = new StreamReader(paramExportFilePath, Encoding.ASCII))
    {
        s1 = r.ReadToEnd();
    }
    String s2 = s1.Replace("string to delete", "replacement string");
    using (StreamWriter w = new StreamWriter(paramExportFilePath, false, Encoding.ASCII))
    {
        w.Write(s2);
    }
