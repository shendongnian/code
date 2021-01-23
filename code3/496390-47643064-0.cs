        private static DateTime NormalizeReadingInterval(DateTime originalTime, int interval)
        {
            if (originalTime.Minute % interval == 0) return originalTime;
            var epochTime = new DateTime(1900, 1, 1);
            var minutes = (originalTime - epochTime).TotalMinutes;
            var numIntervals = minutes / interval;
            var roundedNumIntervals = Math.Round(numIntervals, 0);
            return epochTime.AddMinutes(roundedNumIntervals * interval);
        }
