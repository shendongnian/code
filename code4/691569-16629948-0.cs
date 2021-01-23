    void Main()
    {
        string test = "file(321).pdf";
        string pattern = @"\([0-9]+\)\.";
        bool m = Regex.IsMatch(test, pattern);
        if(m == true)
           test = Regex.Replace(test, pattern, ".");
           
       Console.WriteLine(test);
    }
