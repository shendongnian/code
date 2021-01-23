    private static bool IsLocked(string fileName)
    {
        if (!File.Exists(fileName)) return false;
    
        try {
            FileStream file = new FileStream(fileName,FileMode.Open,FileAccess.Write,FileShare.None);
    
            try {
                return false;
            } finally {
                file.Close();
            }
        } catch (IOException) {
            return true;
        }
    }
    
    public void Save(Guid form_Id, IEnumerable<FormData> formData)
    {
        while (IsLocked(formXMLFilePath)) Thread.Sleep(100);
    
        FileStream file = new FileStream(formXMLFilePath,FileMode.Create,FileAccress.Write,FileShare.None);
        
        try {
            doc.Save(file);
        } finally {
            file.Close();
        }
    }
