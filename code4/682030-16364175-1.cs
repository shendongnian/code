    string[] lines = System.IO.File.ReadAllLines(@"yourtextfile");
    foreach (string line in lines)
    {
        listView1.Items.Add(line);
    }
