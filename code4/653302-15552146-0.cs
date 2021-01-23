    static void Main(string[] args)
    {
        Regex re = new Regex(@"(\d+)[^\d]*", RegexOptions.Compiled);
        Match m = re.Match("123 <br /> this is also numb 2");
        if (m.Success)
        {
            Debug.WriteLine(m.Groups[1]);
        }
    }
