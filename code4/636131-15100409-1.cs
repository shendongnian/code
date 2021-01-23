    //GetYourInputValues() refers to however you plans on pulling in these inputs.
    //It wasn't made clear in your post how you planned to do that.
    string[] inputValues = GetYourInputValues(); 
    
    //List that we will build, then sort, then print out.
    List<DateTime> sortedDateTime = new List<DateTime>();
    
    //Parse them into DateTime variables
    foreach(var input in inputValues)
    {
        DateTime inputDate;
        if(DateTime.TryParse(input, inputDate))
            sortedDateTime.Add(inputDate);
    }
    //Sort them ascending (for descending, flip a and b values)
    sortedDateTime.Sort((a, b) => a.CompareTo(b));
    //Print out the newly sorted values to console.
    foreach(DateTime dt in sortedDateTime)
    {
        Console.WriteLine(dt.ToString("MM/dd/yy hh:mm:ss tt")):
    }
