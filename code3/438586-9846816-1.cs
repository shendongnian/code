        List<string> listBoxFiles = new List<string>() { "1.avi", "2.avi", "3.wrong" };
        List<string> listToRemove = new List<string>();
        public void Run()
        {
            for (int i = 0; i < listBoxFiles.Count; i++)
            {
                string path = (string)listBoxFiles[i];
                FileInfo fileInfo = new FileInfo(path);
                if (fileInfo.Extension != ".avi")
                {
                    listToRemove.Add(path);
                }
            }
            if (listToRemove.Count != 0)
            {
                //method who convert the files to the new format and add the new files into my Listbox
                (new System.Threading.Thread(sendFilesToConvertToAvi)).Start();
            }
            foreach (string file in listToRemove)
            {
                // remove file name from the UI
                listBoxFiles.Remove(file);
            }
        }
        public void sendFilesToConvertToAvi()
        {
            // Do actual conversion
            foreach (string file in listToRemove)
            {
                File.Delete(file);
            }
        }
