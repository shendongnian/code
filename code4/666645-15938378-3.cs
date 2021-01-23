    Dictionary<string, string> startupinfoDict = new Dictionary<string, string>();
        private void readfiles()
        {
            string startfolder = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            var files = Directory.GetFiles(startfolder).Where(name => !name.EndsWith(".ini"));
            foreach (string file in files)
            {
                startupinfo.Items.Add(Path.GetFileNameWithoutExtension(file));
                startupinfoDict.Add(Path.GetFileNameWithoutExtension(file), file);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string s = listBox1.SelectedItem.ToString();
                if (startupinfoDict.ContainsKey(s))
                {
                    Process.Start(startupinfoDict[s]);
                }
            }
        }
