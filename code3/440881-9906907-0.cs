    bottleneck.Item2.where(entry => entry.ChangeoverTime).ToList().Foreach(entry => {
        avarangechangeOverTimes += entry.ChangeoverTime;
        ++counter;
    });
    
    
    maxchangeOverTimes = bottleneck.Item2.max=(entry => entry.ChangeoverTime);
    
    changeovertime.ChangeoverTimes.AddAll(bottleneck.Item2.select(entry => new new ChangeOverDateValue
                        {
                            ChangeoverValue = entry.ChangeoverTime,
                            Color = ChangeOverTimeToColor(entry.ChangeoverTime),
                            StartTime = entry.StartTime
                        }));
