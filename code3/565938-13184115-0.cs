        private void merge()
        {
            string[] fullFile = new string[152];
            System.IO.StreamWriter data = new System.IO.StreamWriter(filepath);
            for (int i = 1; i < 152; i++)
            {
                try
                {
                    string fullfile = System.IO.File.ReadAllText(filepath);
                    data.WriteLine(fullfile + "return\n");
                    
                }
                catch { }
            }
            data.Close();
        }
