        private void WriteToFile(FileInfo pFile, string pData)
        {
            var fileCopy = pFile.CopyTo(Path.GetTempFileName());
            using (var tempFile = new StreamReader(fileCopy.OpenRead()))
            using (var originalFile = new  StreamWriter(File.Open(pFile.FullName, FileMode.Create)))
            {
                originalFile.Write(pData);
                originalFile.Write(tempFile.ReadToEnd());
                originalFile.Flush();
            }
            fileCopy.Delete();
        }
