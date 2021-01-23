    TimeSpan timeOfDay = DateTime.Now.TimeOfDay;
    TimeSpan startTime = new TimeSpan(3, 30, 00);
    TimeSpan endTime = new TimeSpan(1, 30, 00);
                
    if (timeOfDay > startTime || timeOfDay < endTime)
    {
          Console.WriteLine("Hello World");
    }
    
    timeOfDay = new TimeSpan(2, 30, 00); //testcase
    if (timeOfDay > startTime || timeOfDay < endTime)
    {
         //will never execute.
    }
