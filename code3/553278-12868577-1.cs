        System.IO.FileStream fileStream;
        private void LockFile(string FilePath)
        {
            fileStream = System.IO.File.Open(FilePath, System.IO.FileMode.Open, System.IO.FileAccess.ReadWrite, System.IO.FileShare.None);
            //using System.IO.FileShare.None in the above line should be sufficient, but just to go the extra mile...
            fileStream.Lock(0, fileStream.Length);
        }
        private void UnlockFile()
        {
            if (fileStream != null)
            {
                try { fileStream.Unlock(0, fileStream.Length); }
                finally { fileStream.Dispose(); }
            }
        }
