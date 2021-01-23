        foreach (String s in Directory.EnumerateFiles(@"C:\Test", "*.txt", SearchOption.TopDirectoryOnly))
        {
            string s1 = s;
            new Thread(() =>
            {
                File.Move(s1, s1 + "ok");
            }).Start();                
        }
