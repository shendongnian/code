    class Program
    {
        static void Main(string[] args)
        {
            var document = CalendarService.DaysOfWeek.Serialize();
        }
    }
    public static class CalendarService
    {
        public static List<Calendar> DaysOfWeek
        {
            get
            {
                return new List<Calendar>
                        {
                            new Calendar { Id = 1, Code = "Mo", Name = "Mo" },
                            new Calendar { Id = 2, Code = "Tu", Name = "Tu" },
                            new Calendar { Id = 3, Code = "We", Name = "We" },
                            new Calendar { Id = 4, Code = "Th", Name = "Th" },
                            new Calendar { Id = 5, Code = "Fr", Name = "Fr" },
                            new Calendar { Id = 6, Code = "Sa", Name = "Sa" },
                            new Calendar { Id = 7, Code = "Su", Name = "Su" }
                        };
            }
        }
        public static List<Calendar> MonthsOfYear
        {
            get
            {
                return new List<Calendar>
                    {
                        new Calendar { Id = 1, Code = "Jan", Name = "Jan" },
                        new Calendar { Id = 2, Code = "Feb", Name = "Feb" },
                        new Calendar { Id = 3, Code = "Mar", Name = "Mar" },
                        new Calendar { Id = 4, Code = "Apr", Name = "Apr" },
                        new Calendar { Id = 5, Code = "May", Name = "May" },
                        new Calendar { Id = 6, Code = "Jun", Name = "Jun" },
                        new Calendar { Id = 7, Code = "Jul", Name = "Jul" },
                        new Calendar { Id = 8, Code = "Aug", Name = "Aug" },
                        new Calendar { Id = 9, Code = "Sep", Name = "Sep" },
                        new Calendar { Id = 10, Code = "Oct", Name = "Oct" },
                        new Calendar { Id = 11, Code = "Nov", Name = "Nov" },
                        new Calendar { Id = 12, Code = "Dec", Name = "Dec" },
                    };
            }
        }
    }
    public static class SerializationUtil
    {
        public static T Deserialize<T>(XDocument doc)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (var reader = doc.Root.CreateReader())
            {
                return (T)xmlSerializer.Deserialize(reader);
            }
        }
        public static XDocument Serialize(this object obj)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());
            XDocument doc = new XDocument();
            using (var writer = doc.CreateWriter())
            {
                xmlSerializer.Serialize(writer, obj);
            }
            return doc;
        }
    }
    [Serializable]
    public class Calendar
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
