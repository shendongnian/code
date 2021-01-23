    public class HRData
    {
        public int? HeartRate
        {
            get;
            set;
        }
        public int? Speed
        {
            get;
            set;
        }
        public int? Power
        {
            get;
            set;
        }
        public int? Altitude
        {
            get;
            set;
        }
        public override string ToString()
        {
            return String.Format("Heart rate={0}, Speed={1}, Power={2}, Altitude={3}", HeartRate, Speed, Power, Altitude);
        }
    }
    public static class HRDataExtensions
    {
        static private int? CalculateInt32(this IEnumerable<HRData> data, Func<HRData, int?> valueSelector, Func<IEnumerable<int?>, int?> aggregation)
        {
            List<int?> list = new List<int?>();
            list.AddRange(data.Select(valueSelector));
            return aggregation(list);
        }
        static private int? CalculateDouble(this IEnumerable<HRData> data, Func<HRData, int?> valueSelector, Func<IEnumerable<int?>, double?> aggregation)
        {
            List<int?> list = new List<int?>();
            list.AddRange(data.Select(valueSelector));
            double? result = aggregation(list);
            return (result == null) ? null : (int?)Math.Round(result.Value);
        }
        static public int? MinimumHeartRate(this IEnumerable<HRData> data)
        {
            return data.CalculateInt32(hr => hr.HeartRate, Enumerable.Min);
        }
        static public int? MaximumHeartRate(this IEnumerable<HRData> data)
        {
            return data.CalculateInt32(hr => hr.HeartRate, Enumerable.Max);
        }
        static public int? AverageHeartRate(this IEnumerable<HRData> data)
        {
            return data.CalculateDouble(hr => hr.HeartRate, Enumerable.Average);
        }
        static public int? MinimumSpeed(this IEnumerable<HRData> data)
        {
            return data.CalculateInt32(hr => hr.Speed, Enumerable.Min);
        }
        static public int? MaximumSpeed(this IEnumerable<HRData> data)
        {
            return data.CalculateInt32(hr => hr.Speed, Enumerable.Max);
        }
        static public int? AverageSpeed(this IEnumerable<HRData> data)
        {
            return data.CalculateDouble(hr => hr.Speed, Enumerable.Average);
        }
        static public int? MinimumPower(this IEnumerable<HRData> data)
        {
            return data.CalculateInt32(hr => hr.Power, Enumerable.Min);
        }
        static public int? MaximumPower(this IEnumerable<HRData> data)
        {
            return data.CalculateInt32(hr => hr.Power, Enumerable.Max);
        }
        static public int? AveragePower(this IEnumerable<HRData> data)
        {
            return data.CalculateDouble(hr => hr.Power, Enumerable.Average);
        }
        static public int? MinimumAltitude(this IEnumerable<HRData> data)
        {
            return data.CalculateInt32(hr => hr.Altitude, Enumerable.Min);
        }
        static public int? MaximumAltitude(this IEnumerable<HRData> data)
        {
            return data.CalculateInt32(hr => hr.Altitude, Enumerable.Max);
        }
        static public int? AverageAltitude(this IEnumerable<HRData> data)
        {
            return data.CalculateDouble(hr => hr.Altitude, Enumerable.Average);
        }
    }
    public static class HRDataReader
    {
        static private int? ConvertValue(string[] values, int index)
        {
            if (index >= values.Length)
                return null;
            int value;
            if (int.TryParse(values[index], out value))
                return value;
            return null;
        }
        static public IList<HRData> Read(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException("fileName");
            using (StreamReader sr = new StreamReader(fileName))
            {
                string line;
                // First: Skip to the correct section.
                while ((line = sr.ReadLine()) != null)
                    if (line == "[HRData]")
                        break;
                // Now: Read the HRData
                List<HRData> data = new List<HRData>();
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.StartsWith("[") && line.EndsWith("]"))
                        break;
                    line = line.Trim().Replace("\t", " "); // Remove all tabs.
                    while (line.Contains("  ")) // Remove all duplicate spaces.
                        line = line.Replace("  ", " ");
                    string[] values = line.Split(' '); // Split the line up.
                    data.Add(new HRData
                    {
                        HeartRate = ConvertValue(values, 0),
                        Speed = ConvertValue(values, 1),
                        Power = ConvertValue(values, 2),
                        Altitude = ConvertValue(values, 3)
                    });
                }
                return data;
            }
        }
    }
