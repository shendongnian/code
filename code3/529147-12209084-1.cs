    TimeSpan timeOfDay = DateTime.Now.TimeOfDay;
    TimeSpan startTimeToD = startTime.TimeOfDay;
    TimeSpan endTimeToD = endTime.TimeOfDay;
                
    if (timeOfDay > startTimeToD || timeOfDay < endTimeToD )
    {
          Console.WriteLine("Hello World");
    }
    
    timeOfDay = new TimeSpan(2, 30, 00); //testcase
    if (timeOfDay > startTimeToD || timeOfDay < endTimeToD )
    {
         //will never execute.
    }
