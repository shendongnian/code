        void GetTextFromSelectedFiles()
        {
            List<string> selectedFilesContent = new List<string>();
            for (int i = 0; i < listBox1.SelectedItems.Count; i++)
            {
                selectedFilesContent.Add(ReadFileContent(listBox1.SelectedItems.ToString()));
            }
            //when the loop is done, the list<T> holds all the text from selected files!
        }
        private string ReadFileContent(string path)
        {
            return File.ReadAllText(path);
        }
