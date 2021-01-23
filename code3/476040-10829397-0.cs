    string path = "\\test.txt";//file Loc: *start->file explorer->text.txt*
    if (!File.Exists(path))
    {
        using (StreamWriter sw = File.CreateText(path))
        {
            sw.WriteLine("Hello");
            sw.WriteLine("And");
            sw.WriteLine("Welcome");
        }
    }
    using (StreamReader sr = File.OpenText(path))
    {
        string s = "";
        label1.Text = "";
        while ((s = sr.ReadLine()) != null)
        {
            label1.Text += s;
        }
    }
