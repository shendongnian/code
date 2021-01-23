    Regex re = new Regex(@"^ID\d+   :Value(\d+)\s*$", RegexOptions.IgnoreCase | RegexOptions.Compiled);
    List<string> lines = File.ReadAllLines("mytextfile");
    foreach (string line in lines) {
        string replaced = re.Replace(target, processMatch);
        //Now do what you going to do with the value
    }
    string processMatch(Match m)
    {
        var number = m.Groups[1];
        return String.Format("ID{0}   :NewValue{0}", number);
    }
