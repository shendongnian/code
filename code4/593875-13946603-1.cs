            DirSearch(folderBrowserDialog1.SelectedPath);
        }
        private void DirSearch(string dir)
        {
            try
            {
                string userpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                folderBrowserDialog1.ShowDialog();
                string[] files = Directory.GetFiles(folderBrowserDialog1.SelectedPath, "*.*", SearchOption.AllDirectories);
                if (!dir.Equals(userpath))
                {
                    foreach (var file in files)
                    {
                        listBox1.Items.Add(System.IO.Path.GetFileName(file));
                    }
                    IEnumerable<string> dirs = Directory.EnumerateDirectories(dir);
                    foreach (string dsdir in dirs)
                    {
                        DirSearch(dsdir);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
