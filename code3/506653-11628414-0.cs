    public class Monthlst
    {
        public Monthlst()
        {
            Monday = new List<Monday>();
            Tuesday = new List<Tuesday>();
            Wednesday = new List<Wednesday>();
            Thursday = new List<Thursday>();
            Friday = new List<Friday>();
            Saturday = new List<Saturday>();
            Sunday = new List<Sunday>();
        }
        public List<Monday> Monday { get; set; }
        public List<Tuesday> Tuesday { get; set; }
        public List<Wednesday> Wednesday { get; set; }
        public List<Thursday> Thursday { get; set; }
        public List<Friday> Friday { get; set; }
        public List<Saturday> Saturday { get; set; }
        public List<Sunday> Sunday { get; set; }
    }
    public class Monday
    {
        public int days { get; set; }
    }
    public class Tuesday
    {
        public int days { get; set; }
    }
    public class Wednesday
    {
        public int days { get; set; }
    }
    public class Thursday
    {
        public int days { get; set; }
    }
    public class Friday
    {
        public int days { get; set; }
    }
    public class Saturday
    {
        public int days { get; set; }
    }
    public class Sunday
    {
        public int days { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var objmonth = new Monthlst();
            var wednes = new Wednesday {days = 5};
            objmonth.Wednesday.Add(wednes);
        }
    }
