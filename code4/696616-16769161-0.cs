    public IList<Reading[]> GetFirstAndLastReadings(List<Meter> meterList, DateTime start, DateTime end)
         {       
            IList<Reading[]> fAndlReadingsList = new List<Reading[]>();
                
                meterList.ForEach(x => x.readings.ForEach(y =>
                {
                    var readingList = new List<Reading>();
                    if (y.time >= startTime && y.time <= endTime)
                    {
                          readingList.Add(y);
                          fAndlReadingsList.Add(new Reading[] { readingList.OrderBy(reading => reading.time).First(), readingList.OrderBy(reading => reading.time).Last() });
                    }
                }));
            
           return fAndlReadingsList;
        }
