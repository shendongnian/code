        if (openFD.ShowDialog() != DialogResult.Cancel)
        {
            chosenFile = openFD.FileName;
            string directoryPath = Path.GetDirectoryName(chosenFile); 
            string dirName = System.IO.Path.GetDirectoryName(openFD.FileName);
            using (FileStream stream = new FileStream(chosenFile, FileMode.Open, FileAccess.Read))
            {
                size = (int)stream.Length;
                data = new byte[size];
                stream.Read(data, 0, size);
            }
            while (printCount < size)
            {
                richTextBox1.Text += string.Format( "{0:X} ", data[printCount];
                printCount++;
            }
        }
