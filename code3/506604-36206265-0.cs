    public static class FileHelper
    {
        public static void ReplaceFileContents(string fileName, Func<String, string> replacementFunction)
        {
            using (FileStream fileStream = new FileStream(
                    fileName, FileMode.OpenOrCreate,
                    FileAccess.ReadWrite, FileShare.None))
            {
                StreamReader streamReader = new StreamReader(fileStream);
                string currentContents = streamReader.ReadToEnd();
                var newContents = replacementFunction(currentContents);
                fileStream.SetLength(0);
                StreamWriter writer = new StreamWriter(fileStream);
                writer.Write(newContents);
                writer.Close();
            }
        }
    }
