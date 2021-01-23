    public class Object1
    {
        public TimeSpan? Time { get; set; }
        public List<string> Parameters { get; set; }
        public Object1(TimeSpan? time, params string[] parameters)
        {
            Time = time;
            Parameters = parameters.ToList();
        }
    }
