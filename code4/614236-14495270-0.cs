    string RunIDStartTime = "5,Jan 23 2013 9:31AM";
    int Run_ID = 0;
    DateTime StartTime = DateTime.MinValue;
    string[] splittedArray = RunIDStartTime.Split(',');
    if (splittedArray.Length >= 2)
    {
        if (int.TryParse(splittedArray[0], out Run_ID))
        {
            //valid ID
        }
        else
        {
            //Invalid ID
        }
        if(DateTime.TryParseExact(splittedArray[1],"MMM d yyyy h:mmtt",CultureInfo.InvariantCulture,DateTimeStyles.None, out StartTime))
        {
            //Valid date
        }
        else
        {
            //invalid date
        }
    }
