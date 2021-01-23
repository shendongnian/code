    public class StatsConverter : JavaScriptConverter
    {
        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            if (dictionary == null)
                throw new ArgumentNullException("dictionary");
            else if (type == typeof(Statistics))
            {
                Statistics statistics = null;
                Sample sample = null;
                {
                    foreach (var item in dictionary.Keys)
                    {
                        if (dictionary[item] is string && item.Contains("duration"))
                            sample.Duration = float.Parse(dictionary[item].ToString());
                        else if (dictionary[item] is string && item.Contains("date"))
                            sample.Date = DateTime.Parse((dictionary[item].ToString()));
                        else if (dictionary[item] is string && item.Contains("sample"))
                        {
                            sample = new Sample();
                            statistics.Samples.Add(sample);
                        }
                        else if (dictionary[item] is string && item.Contains("statistics"))
                            statistics = new Statistics();
                    }
                }
                return statistics;
            }
            return null;
        }    
        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override IEnumerable<Type> SupportedTypes
        {
            get { return new ReadOnlyCollection<Type>(new List<Type>(new Type[] { typeof(Statistics)})); }
        }
    }
