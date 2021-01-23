            string Path = @"C:\test.txt";
            List<string> BlockedHosts = new List<string>();
            using (StreamReader read = new StreamReader(Path))
            {
                while (!read.EndOfStream)
                {
                    string[] data = read.ReadLine().Split(' ');
                    if (data.Count() >= 3)
                    {
                        if (data[0] == "127.0.0.1" && data[2] == "#onlythis")
                        {
                            BlockedHosts.Add(data[1]);
                        }
                    }
                }
            }
         //Setting data in listbox
         listBox1.DataSource = BlockedHosts;
