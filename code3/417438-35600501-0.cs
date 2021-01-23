    public class SlimHexIdGenerator : IIdGenerator
    {
        private readonly DateTime _baseDate = new DateTime(2016, 1, 1);
        private readonly IDictionary<long, IList<long>> _cache = new Dictionary<long, IList<long>>();
        public string NewId()
        {
            var now = DateTime.Now.ToString("HHmmssfff");
            var daysDiff = (DateTime.Today - _baseDate).Days;
            var current = long.Parse(string.Format("{0}{1}", daysDiff, now));
            return IdGeneratorHelper.NewId(_cache, current);
        }
    }
	
	
    static class IdGeneratorHelper
    {
        public static string NewId(IDictionary<long, IList<long>> cache, long current)
        {
            if (cache.Any() && cache.Keys.Max() < current)
            {
                cache.Clear();
            }
            if (!cache.Any())
            {
                cache.Add(current, new List<long>());
            }
            string secondPart;
            if (cache[current].Any())
            {
                var maxValue = cache[current].Max();
                cache[current].Add(maxValue + 1);
                secondPart = maxValue.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                cache[current].Add(0);
                secondPart = string.Empty;
            }
            var nextValueFormatted = string.Format("{0}{1}", current, secondPart);
            return UInt64.Parse(nextValueFormatted).ToString("X");
        }
    }
