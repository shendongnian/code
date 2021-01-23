            string input = "blah blah";
            string file_content;
            FolderBrowserDialog fld = new FolderBrowserDialog();
            if (fld.ShowDialog() == DialogResult.OK)
            {
                DirectoryInfo di = new DirectoryInfo(fld.SelectedPath);
                foreach(string f  in Directory.GetFiles(fld.SelectedPath))
                {
                    file_content = File.ReadAllText(f);
                    if (file_content.Contains(input))
                    {
                        //string found
                        break;
                    }
                }
                
            }
