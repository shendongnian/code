    string[] text = System.IO.File.ReadAllLines(file);
    foreach (string line in text)
    {
           listBox2.Items.Add(line);
    }
