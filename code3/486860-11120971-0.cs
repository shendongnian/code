    StreamReader reader = new StreamReader(@"C:\Users\jdudley\file.txt");
    // Will be incremented every time ID shows up so it must started at -1 so we don't
    // try and start inserting at 1.
    int rowIndex = -1;
    while (!reader.EndOfStream)
    {
        string line = reader.ReadLine();
        string[] parsedLine = line.Split(new char[] { '=' });
        if(!this.dataGridView1.Columns.Contains(parsedLine[0]))
        {
            dataGridView1.Columns.Add(parsedLine[0],parsedLine[0]);
        }
        if (parsedLine[0].Trim().Equals("id"))
        {
            rowIndex++;
            dataGridView1.Rows.Add();
        }
        dataGridView1[parsedLine[0], rowIndex].Value = parsedLine[1];
    }
