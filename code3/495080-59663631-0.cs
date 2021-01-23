        // TimeSpan result
        var approxUpTime = TryApproximateUpTime();
        private static TimeSpan? TryApproximateUpTime()
        {
            TimeSpan? retVal;
            var envTickCountInMs =
                Environment.TickCount;
            try
            {
                retVal = 
                    envTickCountInMs > 0
                        ?
                            new DateTime()
                                .AddMilliseconds(Environment.TickCount) -
                                    DateTime.MinValue
                        :
                            new TimeSpan(
                                new DateTime(
                                    ((long)int.MaxValue + (envTickCountInMs & int.MaxValue)) * 10 * 1000).Ticks);
            }
            catch (Exception)
            {
                // IGNORE
                retVal = null;
            }
            return retVal;
        }
