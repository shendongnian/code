        public void SplitFiles(int[] newFiles, string sourceFilePath, int processorCount)
        {
            string sourceDirectory = System.IO.Path.GetDirectoryName(sourceFilePath);
            string sourceFileName = System.IO.Path.GetFileNameWithoutExtension(sourceFilePath);
            string extension = System.IO.Path.GetExtension(sourceFilePath);
            using (StreamReader Reader = new StreamReader(sourceFilePath))
            {
                for (int i = 0; i < newFiles.Length; i++)
                {
                    string destinationFileNameWithExtension = string.Format("{0}{1}{2}", sourceFileName, i, extension);
                    string destinationFilePath = System.IO.Path.Combine(sourceDirectory, destinationFileNameWithExtension);
                    if (!File.Exists(destinationFilePath))
                    {
                        for (int x = 0; x < newFiles[i]; x++)
                        {
                            DataWriter(Reader.ReadLine(), destinationFilePath);
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }
