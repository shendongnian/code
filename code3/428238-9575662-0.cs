        static void FindFiles()
        {
            for (int i = 0; i < FileTypesDict.Length; i++)
            {
                var fileType = FileTypesDict[i, 0];
                var action = FileTypesDict[i, 1];
                string[] files = Directory.GetFiles(FilePath, fileType);
            }
        }
