    string[] files = Directory.GetFiles(@"C:\Users\User\Desktop\AnyFolder");   // You should include System.IO;
    foreach (string s in files)
    {
        string text = File.ReadAllText(s);
        text = text.Replace("old text", "new text");
        StreamWriter writer = new StreamWriter(s);
        writer.Write(text);
    }
