    string t = Path.GetDirectoryName(Application.LocalUserAppDataPath);
    string[] split = t.Split('\\');
    List<string> b = split.ToList();
    b.RemoveRange(3, split.Length-3);
    t = String.Join(@"\", b.ToArray());
