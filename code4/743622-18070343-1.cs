            StreamReader sr = new StreamReader("textfile3.txt");
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                int index = line.IndexOf("SourceFolderPath");
                if (index >= 0)
                {
                    listBox1.Items.Add(line.Substring(index + 16).Trim());
                }
            }
