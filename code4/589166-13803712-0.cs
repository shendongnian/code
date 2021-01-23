                while (startDates <= endDates)
                {
                    if (startDates.DayOfWeek != DayOfWeek.Saturday **&&** startDates.DayOfWeek != DayOfWeek.Sunday)
                    {
                        Holiday holiday1 = new Holiday();
                        holiday1.PersonId = PersonId.Value;
                        holiday1.HolidayDate = startDates;
    
                        db.Holidays.AddObject(holiday1);
                        db.SaveChanges();
    
    
                         
                    }
                    **startDates = startDates.AddDays(1);**
                }
