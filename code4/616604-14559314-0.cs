    internal class DateTimeComparer : IEqualityComparer<DateTime>
    {
        public bool Equals(DateTime x, DateTime y)
        {
            return GetHashCode(x) == GetHashCode(y);  
            // In general, this shouldn't be written (because GetHashCode(x) can equal GetHashCode(y) even if x != y (with the given  comparer)). 
            // But here, we have: x == y <=> GetHashCode(x) == GetHashCode(y)
        }
        public int GetHashCode(DateTime obj)
        {
            return (int)((obj - new TimeSpan(0, 30, 0)).Ticks / new TimeSpan(1, 0, 0).Ticks);
        }
    }
