        string folderPath;
        const int ITEMS_PER_FILE=100;
        void AskUserForFolder()
        {
            folderPath = string.Empty;
            using (FolderBrowserDialog fdb = new FolderBrowserDialog())
            {
                if (fdb.ShowDialog() == DialogResult.OK)
                {
                    folderPath = fdb.SelectedPath;
                    // MessageBox.Show(folderPath);
                }
            }
        }
        void SaveItems(ListBox listBox, int seed)
        {
            int total = listBox.Items.Count;
           
            for ( int fileCount=0;fileCount<listBox.Items.Count/ITEMS_PER_FILE;++fileCount)
            {
                using (StreamWriter sw = new StreamWriter(folderPath + "\\" + GetFilePath(folderPath, "filename.txt",ref seed)))
                {
                    for (int i = 0; i < listBox.Items.Count; i++)
                    {
                        sw.WriteLine(listBox.Items[i+(ITEMS_PER_FILE*fileCount)]);
                    }
                    sw.Close();
                }
            }
        }
        //I'm not sure about the rest though. Something like this for the filenames perhaps
        /// <summary>
        /// Gets a filename that has not been used before by incrementing a number at the end of the filename
        /// </summary>
        /// <param name="seed">seed is passed in as a referrect value and acts as a starting point to itterate through the list
        /// By passing it in as a reference we can save ourselves from having to itterate unneccssarily for the start each time
        /// </param>
        /// <returns>the path of the file</returns>
        string GetFilePath(string folderpath, string fileName,string extension,ref int seed)
        {
            FileInfo fi = new FileInfo(string.Format("{0}\\{1}{2}.{3}", folderPath, fileName, seed,extension));
            while (fi.Exists)
            {
                fi = new FileInfo(string.Format("{0}\\{1}{2}.{3}", folderPath, fileName, ++seed,extension));
            }
            return fi.FullName;
        }
