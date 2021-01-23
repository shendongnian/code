    public int GetEnumIndex(VisibleDayOfWeek day)
    {
         var allValues = Enum.GetValues(typeof(VisibleDayOfWeek));
         for (int i = 0; i <  a.Length ; i++)
         {
             if ((VisibleDayOfWeek)allValues.GetValue(i) == day)
                 return i;
         }
         return -1;
     }
