        private void Form1_Load(object sender, EventArgs e)
        {
            const string path = @"c:/yourpath";
            List<string> extensions = new List<string> { "EXE", "PNG" };
            string[] files = GetFilesWithExtensions(path, extensions);
            checkedListBox1.Items.AddRange(files);
        }
        private string[] GetFilesWithExtensions(string path, List<string> extensions)
        {
            string[] allFilesInFolder = Directory.GetFiles(path);
            return allFilesInFolder.Where(f => extensions.Contains(f.ToUpper().Split('.').Last())).ToArray();
        }
