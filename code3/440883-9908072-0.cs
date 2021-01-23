    var averagechangeOverTimes = bottleneck.Item2
                                           .Where(a => a > 0)
                                           .Sum(entry => entry.ChangeoverTime);
    
    changeovertime.ChangeoverTime.Add(bottleneck.Item2
                                     .Select(new ChangeOverDateValue{
                                                            ChangeoverValue = entry.ChangeoverTime,
                                                            Color = ChangeOverTimeToColor(entry.ChangeoverTime),
                                                            StartTime = entry.StartTime
                                                          });
    var maxchangeOverTimes = bottleneck.Item2.Max();
