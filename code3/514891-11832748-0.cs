    public static class DateTimeExtension
    {
        public static DateTime GetPositionalDate(this DateTime BaseDate, DayOfWeek WeekDay, int position)
        {
            if (position < 1)
            {
                throw new Exception("Invalid position");
            }
            else
            {
                DateTime ReturnDate = new DateTime(BaseDate.Year, BaseDate.Month, BaseDate.Day);
                int PositionControl = 1;
                bool FoundDate = false;
                while(ReturnDate.DayOfWeek != WeekDay)
                {
                    ReturnDate = ReturnDate.AddDays(1);
                }
                while (!FoundDate && PositionControl <= position)
                {
                    PositionControl++;
                    if (PositionControl == position)
                    {
                        FoundDate = true;
                    }
                    else
                    {
                        ReturnDate = ReturnDate.AddDays(7);
                    }
                }
                if (FoundDate)
                {
                    return ReturnDate;
                }
                else
                {
                    throw new Exception("Date not found");
                }
            }
        }
    }
