    public class Candle
    {
        public long Id { get; set; }
        public Period Period { get; set; }
        public DateTime Timestamp { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Open { get; set; }
        public double Close { get; set; }
        public double BuyVolume { get; set; }
        public double SellVolume { get; set; }
    }
    public enum Period
    {
        Minute = 1,
        FiveMinutes = 5,
        QuarterOfAnHour = 15,
        HalfAnHour = 30
    }
        private List<Candle> AggregateCandlesIntoRequestedTimePeriod(Period rawPeriod, Period requestedPeriod, List<Candle> candles)
        {
            if (rawPeriod != requestedPeriod)
            {
                int rawPeriodDivisor = (int) requestedPeriod;
                candles = candles
                            .GroupBy(g => new { TimeBoundary = new DateTime(g.Timestamp.Year, g.Timestamp.Month, g.Timestamp.Day, g.Timestamp.Hour, (g.Timestamp.Minute / rawPeriodDivisor) * rawPeriodDivisor , 0) })
                            .Where(g => g.Count() == rawPeriodDivisor )
                            .Select(s => new Candle
                            {
                                Period = requestedPeriod,
                                Timestamp = s.Key.TimeBoundary,
                                High = s.Max(z => z.High),
                                Low = s.Min(z => z.Low),
                                Open = s.First().Open,
                                Close = s.Last().Close,
                                BuyVolume = s.Sum(z => z.BuyVolume),
                                SellVolume = s.Sum(z => z.SellVolume),
                            })
                            .OrderBy(o => o.Timestamp)
                            .ToList();
            }
            return candles;
        }
