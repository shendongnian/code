If the difference between endTime and startTime is **greater than or equal to 60 Minutes** , the statement:endTime.Subtract(startTime).Minutes; will always return 0. Obviously which is not desired when we are only talking about minutes (not hours here). <br>
Here are some of the ways if you want to get total number of minutes(in different typecasts): 
    // Default value that is returned is of type *double* 
    double double_minutes = endTime.Subtract(startTime).TotalMinutes; 
    int integer_minutes = (int)endTime.Subtract(startTime).TotalMinutes; 
    long long_minutes = (long)endTime.Subtract(startTime).TotalMinutes; 
    string string_minutes = (string)endTime.Subtract(startTime).TotalMinutes; 
