    var avarangechangeOverTimes = bottleneck.Item2
                                        .Where(entry => entry.ChangeOverTime > 0)
                                        .Sum(entry => entry.ChangeOverTime);
    var maxchangeOverTimes = bottleneck.Item2
                                        .Max(entry => entry.ChangeOverTime);
    bottleneck.Item2.ToList()
            .ForEach(entry => changeovertime.ChangeoverTimes.Add
                                        (
                                            new ChangeOverDateValue {
                                                ChangeoverValue = entry.ChangeoverTime,
                                                Color = ChangeOverTimeToColor(entry.ChangeoverTime),
                                                StartTime = entry.StartTime
                                            }
                                       )
                                       );
