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
                        // Read all the lines relevant to this destination file
                        // and temporarily store them in memory
                        StringBuilder destinationText = new StringBuilder();
                        for (int x = 0; x < newFiles[i]; x++)
                        {
                            destinationText.Append(Reader.ReadLine());
                        }
                        DataWriter(destinationFilePath, destinationText.ToString());
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }
    private static void DataWriter(string destinationFilePath, string content)
    {
        using (StreamWriter sr = new StreamWriter(destinationFilePath))
        {
            {
                sr.Write(content);
            }
        }
    }
