    class Program
    {
        public class TNews
        {
            public DateTime? SendTime { get; set; }
            public string Id;
        }
        static void Main(string[] args)
        {
            var tnews = new TNews[]
            {
                new TNews { SendTime = new DateTime(2012,8,20), Id="2012-08-20" },
                new TNews { SendTime = new DateTime(2012,8,20,12,20,0), Id="2012-08-20 12:20" },
                new TNews { SendTime = new DateTime(2012,8,21), Id="2012-08-21" },
                new TNews { SendTime = null, Id="null" },
            };
            var someDate = new DateTime(2012, 8, 20);
            var rslt = (from t in tnews
                        where t.SendTime.HasValue &&
                            t.SendTime.Value.Date == someDate
                        select t);
            foreach (var t in rslt)
            {
                Console.WriteLine(t.Id);
            }
        }
    }
