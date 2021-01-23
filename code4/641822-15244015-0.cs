    public static void SaveObjectToStorage<T>(T ObjectToSave)
    {
        TextWriter writer;
    
        using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
        {
            using (IsolatedStorageFileStream fs = isf.OpenFile(GetFileName<T>(), System.IO.FileMode.Create))
            {
                writer = new StreamWriter(fs);
                XmlSerializer ser = new XmlSerializer(typeof(T));
                ser.Serialize(writer, ObjectToSave);
                writer.Close();
            }
    
        }
    }
