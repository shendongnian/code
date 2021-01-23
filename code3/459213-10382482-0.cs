    int  _findID = 1;
    List<String> names = new List<string>()
    using (StreamReader reader = new StreamReader("textfile.txt"))
    {
        string line = reader.ReadLine();
        int lineCount = 0;
        while (line != null)
        {
            lineCount++;
            names.Add(line);
            if (lineCount == _findID)
                MessageBox.Show("Line found!!");           
        }
    }
