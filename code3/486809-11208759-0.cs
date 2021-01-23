    public static void WriteStreamToFile(MemoryStream stream, string baseFileName, string extension, out string realFileName)
        {
            realFileName = String.Empty;
            if (stream != null)
                using (IsolatedStorageFile appStorage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    baseFileName = GlobalSettings.NormalizeFileName(baseFileName);
                    realFileName = String.Concat(baseFileName, extension);
                    using (IsolatedStorageFileStream fileStream = appStorage.OpenFile(realFileName, FileMode.Create, FileAccess.Write))
                        stream.WriteTo(fileStream);
                }
        }
        public static void ReadStreamFromFile(MemoryStream stream, string fileName)
        {
            if (stream != null)
                using (IsolatedStorageFile appStorage = IsolatedStorageFile.GetUserStoreForApplication())
                using (IsolatedStorageFileStream fileStream = appStorage.OpenFile(fileName, FileMode.Open, FileAccess.Read))
                    fileStream.CopyTo(stream);
        }
