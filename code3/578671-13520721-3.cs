    string str = "foo\n\r\nbar";
    string temp = Path.GetTempFileName();
    File.WriteAllText(temp, str);
    string str2 = File.ReadAllText(temp);
    Console.WriteLine(string.Join(",", str2.Select(c => ((int)c))));
