            string[] input = File.ReadAllText("textfile3.txt").Split(new string[1] { "SourceFolderPath" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 1; i < input.Count(); i++)
            {
                listBox1.Items.Add(input[i].Substring(0,input[i].IndexOf("Instance") - 1).Trim());
            }
