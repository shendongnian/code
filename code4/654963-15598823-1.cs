    public int GetEnumIndex(VisibleDayOfWeek day, bool ToBeConvertedToDoW)
    {
         var allValues = Enum.GetValues(typeof(VisibleDayOfWeek));
         for (int i = 0; i <  a.Length ; i++)
         {
             if ((VisibleDayOfWeek)allValues.GetValue(i) == day)
             {
                 //if you plan to convert to a DayOfWeek, this will return the
                 //index for the DoW enum
                 if(ToBeConvertedToDoW)
                    return (i % 7);
                 else //else return the actual index from VisibleDayOfWeek enum
                    return i;
             }
         }
         return -1;
     }
