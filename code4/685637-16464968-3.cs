        string folderPath;
        void AskUserForFolder()
        {
            string folderPath = string.Empty;
            using (FolderBrowserDialog fdb = new FolderBrowserDialog())
            {
                if (fdb.ShowDialog() == DialogResult.OK)
                {
                    folderPath = fdb.SelectedPath;
                    // MessageBox.Show(folderPath);
                }
            }
        }
        void SaveItems(ListBox listBox)
        {
            int total = listBox.Items.Count;
            using (StreamWriter sw = new StreamWriter(folderPath + "\\" + GetFilePath()))
            {
                for (int i = 0; i < listBox.Items.Count; i++)
                {
                    sw.WriteLine(listBox.Items[i]);
                }
                sw.Close();
            }
        }
        //I'm not sure about the rest though. Something like this for the filenames perhaps
        string GetFilePath()
        {
            string fileName = "fileName";
            int count = 1;//1 is the seed value
            FileInfo fi = new FileInfo(string.Format("{0}\\{1}\\{2}", folderPath, fileName, count));
            while (fi.Exists)
            {
                fi = new FileInfo(string.Format("{0}\\{1}   \\{2}", folderPath, fileName, ++count));
            }
            return fi.FullName;
        }
