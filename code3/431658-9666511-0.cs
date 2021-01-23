    public static class SeatGapFinder
    {
        public static bool Check(IEnumerable<Seats> seats)
        {
            using (var enumerator = seats.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                {
                    return false;
                }
                var lastValue = enumerator.Current.PosX;
                while (enumerator.MoveNext())
                {
                    lastValue++;
                    if (enumerator.Current.PosX != lastValue)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
