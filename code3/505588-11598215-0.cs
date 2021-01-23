    private bool IsValid(string str)
     {
        Regex r = new Regex(@"^[a-z]+$");
        Console.WriteLine(str + " : " + r.IsMatch(str).ToString()); 
        return r.IsMatch(str);
     }
