    public void Main()
    {
    	string matchstr = "\\bC#BKN00([0-9]{1})\\b";
    	string modify = null;
    	modify = Regex.Replace("C#BKN005", matchstr, "ceiling $1 hundred broken.");
    	Console.WriteLine(modify);
    	Console.WriteLine(Regex.Replace("BKN005", matchstr, "ceiling $1 hundred broken."));
    	Console.ReadLine();
    }
