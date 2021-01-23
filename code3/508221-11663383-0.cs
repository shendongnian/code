    public static void Replace(string filePath, string searchText, string replaceText)
    {
       string newText = File.ReadAllText(filePath).Replace(searchText, replaceText));
       File.Delete(filePath);
       File.WriteAllText(newFilePath, newText);
    }
