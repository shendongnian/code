    static void Main(string[] args)
    {
        var subjects = new string[] {"substringof('xxxx',Name)", "substringof('B's',Name)", "substringof('B'',Name)", "substringof('''',Name)"};
        
        Regex reg = new Regex(@"substringof\('(.+?)'\s*,\s*([\w\[\]]+)\)");
        foreach (string subject in subjects) {
            string result = reg.Replace(subject, delegate(Match m) { return m.Groups[2].Value + ".Contains(\"" + m.Groups[1].Value.Replace("''", "'") + "\")"; });
            Console.WriteLine(result);
        }
    }
