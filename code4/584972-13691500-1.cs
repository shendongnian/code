    public static IEnumerable<Tuple<DateTime, DateTime>> SplitDateRange(DateTime start, DateTime end, int dayChunkSize)
            {
                
                var dateCount = (end - start).TotalDays / 5;
                for (int i = 0; i < dateCount; i++)
                {
                    yield return Tuple.Create(start.AddDays(dayChunkSize * i)
                                            , start.AddDays(dayChunkSize * (i + 1)) > end 
                                             ? end : start.AddDays(dayChunkSize * (i + 1)));
                }
          
            }   
