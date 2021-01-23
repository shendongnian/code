    public int InsertLogDetails(string RunIDStartTime, int Distribution_ID, List<string> additions, List<string> removals, bool status, string ErrorMessage)
    {
              
        var tokens = RunIDStartTime.split(',');
        int Run_ID= int.Parse(tokens[0]);
        DateTime StartTime = DateTime.Parse(tokens[1],"MMM d yyyy h:mmtt", CultureInfo.InvariantCulture, DateTimeStyles.None);        
    }
