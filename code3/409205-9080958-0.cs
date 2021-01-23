        private void NewFolder(string path) 
        {
            string name = @"\New Folder";
            string current = name;
            int i = 0;
            while (Directory.Exists(path + current))
            {
                i++;
                current = String.Format("{0} {1}", name, i);
            }
            Directory.CreateDirectory(path + current);
        }
