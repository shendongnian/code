    private static void UpdateStudent(XElement data, int studentId)
    {
        XDocument student = ReadStudent(studentId);
        student.Root.Add(data);
        SaveStudent(studentId, student);
    }
    private static void SaveStudent(int studentId, XDocument data)
    {
        string compressed = CompressData(data.ToString());
        SaveStudentData(studentId, compressed);
    }
    private static XDocument ReadStudent(int studentId)
    {
        string data = GetStudentFromDatabase(studentId);
        XDocument ret;
        if (string.IsNullOrEmpty(data))
        {
            ret = XDocument.Parse("<student></student>");
        }
        else
        {
            string decompressed = DecompressData(data).TrimEnd('\0');
            ret = XDocument.Parse(decompressed);
        }
        return ret;
    }
 
    // These two methods would query the database but for demo, just store
    // in a static member
    private static string GetStudentFromDatabase(int studentId)
    { 
        return _data;
    }
    private static void SaveStudentData(int studentId, string data)
    {
        _data = data;
    }
    private static string _data;
