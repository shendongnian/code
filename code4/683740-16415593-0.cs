    FileInfo fi = new FileInfo("test.txt");
    
    public Form1()
    {
        foreach (string str in File.ReadAllLines(fi.FullName))
        {
            string[] temp;
            temp = str.Split(' ');
            if (temp[1] == "0xD176234F81150469:")
                list.Add(temp[2] + " (" + temp[1] + ")");
        }
    }
