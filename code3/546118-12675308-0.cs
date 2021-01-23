    public class Shift
        {
            public string description { get; set; }
            public int id { get; set; }
            public int venueId { get; set; }
        }
        public class Result
        {
            public object account { get; set; }
            public object checkInfo { get; set; }
            public object command { get; set; }
            public List<Shift> shifts { get; set; }
        }
        public class RootObject
        {
            public Result result { get; set; }
        }
