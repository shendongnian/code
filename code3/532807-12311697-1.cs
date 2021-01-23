        string timestring = "Sep  6 16:03";
       //string[] array = timestring.Split(" ".ToCharArray(),StringSplitOptions.RemoveEmptyEntries);
       //timestring = string.Join(" ", array);
        timestring = System.Text.RegularExpressions.Regex.Replace(timestring, @"\s+", " ");
    
        CultureInfo provider = new CultureInfo("en-US");
        DateTime _fileDateTime = DateTime.ParseExact(timestring, "MMM d H:mm", provider);
