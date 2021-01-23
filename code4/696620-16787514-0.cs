            /// <summary>
            /// Fills the result data with meter readings matching the filters.
            /// only take first and last reading for each meter in period.
            /// </summary>
            /// <param name="intervals">time intervals</param>
            /// <param name="meterIds">list of meter ids.</param>
            /// <param name="result">foreach meter id , a list of relevant meter readings</param>
            private void AddFirstLastReadings(List<RangeFilter<DateTime>> intervals, List<int> meterIds, Dictionary<int, List<MeterReading>> result)
            {
                foreach (RangeFilter<DateTime> interval in intervals)
                {
                    var metersFirstAndLastReading = m_context.Meter.Where(m => meterIds.Contains(m.Id)).Select(m => new
                    {
                        MeterId = m.Id,
                        FirstReading = m.MeterReading
                                        .Where(r => r.TimeStampLocal >= interval.FromVal && r.TimeStampLocal < interval.ToVal)
                                        .OrderBy(r => r.TimeStampLocal)
                                        .FirstOrDefault(),
                        LastReading = m.MeterReading
                                        .Where(r => r.TimeStampLocal >= interval.FromVal && r.TimeStampLocal < interval.ToVal)
                                        .OrderByDescending(r => r.TimeStampLocal)
                                        .FirstOrDefault()
                    });
    
                    foreach (var firstLast in metersFirstAndLastReading)
                    {
                        MeterReading firstReading = firstLast.FirstReading;
                        MeterReading lastReading = firstLast.LastReading;
    
                        if (firstReading != null)
                        {
                            result[firstLast.MeterId].Add(firstReading);
                        }
    
                        if (lastReading != null && lastReading != firstReading)
                        {
                            result[firstLast.MeterId].Add(lastReading);
                        }
    
                    }
    
                }
            }
    
    
        }
