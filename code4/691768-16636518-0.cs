    string str = "Hello1,Hello,Hello2";
    string another = "Hello5";
    bool retVal = str.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                       .Any(p => p.Equals(another));
    if (retVal)
    {
       ViewBag.test = "Match";
    }
    else
    {
       ViewBag.test = "No Match"; //not work
    }
