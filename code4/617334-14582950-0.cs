    using System.IO;
    namespace FileDownloadInMvc3.Models
    {
        public static class ExtensionMethods
        {
            public static byte[] GetFileData(this string fileName, string filePath)
            {
                var fullFilePath = string.Format("{0}/{1}", filePath, fileName);
                if (!File.Exists(fullFilePath))
                    throw new FileNotFoundException("The file does not exist.", 
                        fullFilePath);
                return File.ReadAllBytes(fullFilePath);
            }
        }
    }
