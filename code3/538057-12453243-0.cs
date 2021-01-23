    [WebMethod]
    public string saveFileUploaderName(string name)
    {
        string path = "c:\\Test";
        string filename = "Test.txt";
        string completeFileName = Path.Combine(path,filename);
        File.AppendAllText(completeFileName, name);
        return "success";
    }
