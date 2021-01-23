    List<DateTime> SortedDateTime = new List<DateTime>();
    
    string[] inputValues = GetYourInputValues(); // Referring to however you are getting your input values
    //Parse them into DateTime variables
    foreach(var input in inputValues)
    {
        DateTime inputDate;
        if(DateTime.TryParse(input, inputDate))
            SortedDateTime.Add(inputDate);
    }
    //Sort them decending
    SortedDateTime.Sort((a, b) => b.CompareTo(a));
    
    foreach(DateTime dt in SortedDateTime)
    {
        Console.WriteLine(dt.ToString("[FORMAT]")):
    }
