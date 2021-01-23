                double minIntervalAsDouble = Convert.ToDouble(minInterval);
                if (minIntervalAsDouble <= 0)
                {
                    string message = "minInterval must be a positive number, exiting";
                    Log.getInstance().Info(message);
                    throw new Exception(message);
                }
                else if (minIntervalAsDouble < 60.0 && 60.0 % minIntervalAsDouble != 0)
                {
                    string message = "60 must be divisible by minInterval...exiting";
                    Log.getInstance().Info(message);
                    throw new Exception(message);
                }
                else if (minIntervalAsDouble >= 60.0 && (24.0 % (minIntervalAsDouble / 60.0)) != 0 && (24.0 % (minIntervalAsDouble / 60.0) != 24.0))
                {
                    //hour part must be divisible...
                    string message = "If minInterval is greater than 60, 24 must be divisible by minInterval/60 (hour value)...exiting";
                    Log.getInstance().Info(message);
                    throw new Exception(message);
                }
                var groups = datas.GroupBy(x =>
                {
                    if (minInterval < 60)
                    {
                        var stamp = x.Created;
                        stamp = stamp.AddMinutes(-(stamp.Minute % minInterval));
                        stamp = stamp.AddMilliseconds(-stamp.Millisecond);
                        stamp = stamp.AddSeconds(-stamp.Second);
                        return stamp;
                    }
                    else
                    {
                        var stamp = x.Created;
                        int hourValue = minInterval / 60;
                        stamp = stamp.AddHours(-(stamp.Hour % hourValue));
                        stamp = stamp.AddMilliseconds(-stamp.Millisecond);
                        stamp = stamp.AddSeconds(-stamp.Second);
                        stamp = stamp.AddMinutes(-stamp.Minute);
                        return stamp;
                    }
                }).Select(o => new
                {
                    o.Key,
                    min = o.Min(f=>f.Created),
                    max = o.Max(f=>f.Created),
                    o
                }).ToList();
