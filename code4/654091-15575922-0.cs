    public class Object1
    {
        public Object1()
        {
            this.Parameters = new List<string>();
        }
        public TimeSpan? Time { get; set; }
        public List<string> Parameters { get; set; }
        public string Param
        {
            get
            {
                return string.Join(",", this.Parameters.OrderBy(o => o).ToArray());
            }
        }
    }
