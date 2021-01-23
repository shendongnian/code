    var averagechangeOverTimes = bottleneck.Item2
                                           .Where(entry => entry.ChangeoverTime > 0)
                                           .Sum(entry => entry.ChangeoverTime);
    counter = bottleneck.Item2.Count(entry => entry.ChangeoverTime > 0);
    var maxchangeOverTimes = bottleneck.Item2.Max(entry => entry.ChangeoverTimes);
    
    changeovertime.ChangeoverTime.Add(bottleneck.Item2
                                                .Select(entry => new ChangeOverDateValue{
                                                            ChangeoverValue = entry.ChangeoverTime,
                                                            Color = ChangeOverTimeToColor(entry.ChangeoverTime),
                                                            StartTime = entry.StartTime
                                                          });
