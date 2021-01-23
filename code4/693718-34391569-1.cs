    public string GetReadableTimeSpan(TimeSpan value)
    {
     string duration = "";
     var totalDays = (int)value.TotalDays;
     if (totalDays >= 1)
     {
         duration = totalDays + " day" + (totalDays > 1 ? "s" : string.Empty);
         value = value.Add(TimeSpan.FromDays(-1 * totalDays));
     }
     var totalHours = (int)value.TotalHours;
     if (totalHours >= 1)
     {
         if (totalDays >= 1)
         {
             duration += ", ";
         }
         duration += totalHours + " hour" + (totalHours > 1 ? "s" : string.Empty);
         value = value.Add(TimeSpan.FromHours(-1 * totalHours));
     }
     var totalMinutes = (int)value.TotalMinutes;
     if (totalMinutes >= 1)
     {
         if (totalHours >= 1)
         {
             duration += ", ";
         }
         duration += totalMinutes + " minute" + (totalMinutes > 1 ? "s" : string.Empty);
     }
     return duration;
    }
