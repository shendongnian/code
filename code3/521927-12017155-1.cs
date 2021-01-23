    public class User
    {
        public int Id { get; set; }
        public string Value1 { get; set; }
        public string Value2 { get; set; }
        public string Value3 { get; set; }
        public override string ToString()
        {
            return string.Format("{0}|{1}|{2}|{3}", Id, Value1, Value2, Value3);
        }
    }
