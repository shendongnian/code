    DayOfWeek Day = DateTime.Today.DayOfWeek;
    int Time = DateTime.Now.Hour;
    if (Day != DayOfWeek.Saturday && Day != DayOfWeek.Sunday)
     {
     if (Time >= 8 && Time <= 16)
     {
       //It is Weekdays work hours from 8 AM to 4 PM
     {
     }
    else
     {
       // It is Weekend
     {
