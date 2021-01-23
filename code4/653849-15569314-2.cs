    List<string> list = new List<string>();
    Func<string, bool, bool> checkName = (name, all) => all
        ? !list.Any(x => !Regex.IsMatch(name, x, RegexOptions.IgnoreCase))
        : list.Any(x => Regex.IsMatch(name, x, RegexOptions.IgnoreCase));
    checkName("filename", true) 
