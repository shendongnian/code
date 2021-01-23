    var maxChangeOverTime = bottleneck.Item2.Max(x => x.ChangeoverTime);
    var averageChangeOverTime = bottleneck.Item2.Average(x => x.ChangeoverTime);
    var result
        = bottleneck.Item2
                    .Select(x => new ChangeOverDateValue
                                 {
                                     ChangeoverValue = x.ChangeoverTime,
                                     Color = ChangeOverTimeToColor(x.ChangeoverTime),
                                     StartTime = x.StartTime
                                 });
    changeovertime.ChangeoverTimes.AddRange(result);
