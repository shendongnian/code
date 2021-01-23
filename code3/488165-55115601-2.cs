    DateTime datetime1 = new DateTime(2019, 03, 15);
    datetime1.GetIso8601WeekOfYear(); //returns 11
    DateTime? datetime2 = new DateTime(2019, 03, 15);
    datetime2.GetIso8601WeekOfYear(); //returns 11
    DateTime? datetime3 = null;
    datetime3.GetIso8601WeekOfYear(); //returns null
