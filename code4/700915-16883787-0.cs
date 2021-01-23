    FileInfo fi = new FileInfo(/*filename*/);
    DateTime dateFile = fi.LastWriteTime;
    DateTime now = DateTime.Now;
    
    if (now.Year == dateFile.Year) { //same year?
       if (now.Month == dateFile.Month) { //same month?
           MessageBox.Show("File has been edited in this month.");
           DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
           Calendar c = dfi.Calendar;
           int fileWeek = c.GetWeekOfYear(dateFile, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
           int nowWeek = c.GetWeekOfYear(now, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
           if (fileWeek == nowWeek) { //same week?
               MessageBox.Show("File has been edited in this week.");
           }
       }
                        
    }
