     public static Dictionary<int, int> map = new Dictionary<int, int>() { { 0, 64 }, { 1, 1 }, { 2, 2 }, { 3, 4 }, { 4, 8 }, { 5, 16 }, { 6, 32 } };
    
    //actually,this gets from a user interface,but we shoul be focus database layer
    WeekDays[] dw = new WeekDays[] {WeekDays.Saturday,WeekDays.Tuesday,WeekDays.Wednesday };
        
    int[] systemDayOfWeekList = new int[daysOfWeek.Length];
        
    for (int i = 0; i < daysOfWeek.Length; i++)
    {
      systemDayOfWeekList[i] = map.FirstOrDefault(e => e.Value == (int)daysOfWeek[i]).Key;
    }
        
    query = query.Where(f => dayOfWeekList.Contains(((int)SqlFunctions.DatePart("dw", f.FromDateTime))));
