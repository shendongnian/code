    protected static Student GetFromClipboard()
    {
        Student student = null;
        IDataObject dataObj = Clipboard.GetDataObject();
        string format = typeof(Student).FullName;
    
        if (dataObj.GetDataPresent(format))
        {
            student = dataObj.GetData(format) as Student;
        }
        return student;
    }
