    public enum Number
    {
        One = 11111,
        Two = 22222,
        Three = 33333,
        Four = 44444,
        Five = 55555
    }
    public class Data
    {
        public Number Code { get; set; }
        public string CodeName { get { return Enum.GetName(typeof(Number), Code); } }
        public ConsoleColor Color { get; set; }
        public int Month { get; set; }
    }
    public class Result
    {
        public Number Code { get; set; }
        public string CodeName { get { return Enum.GetName(typeof(Number), Code); } }
        public ConsoleColor Color { get; set; }
        public int Month1 { get; set; }
        public int Month2 { get; set; }
        public int Month3 { get; set; }
        public int Month4 { get; set; }
        public int Month5 { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var items = new Data[]
            {
                new Data{Code = Number.One, Color = ConsoleColor.Red, Month = 1},
                new Data{Code = Number.One, Color = ConsoleColor.Red, Month = 1},
                new Data{Code = Number.One, Color = ConsoleColor.Red, Month = 2},
                new Data{Code = Number.Two, Color = ConsoleColor.Green, Month = 2},
                new Data{Code = Number.Three, Color = ConsoleColor.Yellow, Month = 3},
                new Data{Code = Number.Four, Color = ConsoleColor.Blue, Month = 4},
                new Data{Code = Number.Four, Color = ConsoleColor.Blue, Month = 4},
                new Data{Code = Number.Five, Color = ConsoleColor.White, Month = 5},
            };
            var results = items.GroupBy(x => x.Code).Select(
                x => x.GroupBy(y => y.Color)
                      .Select(z => new Result
                      {
                          Code = x.Key,
                          Color = z.Key,
                          Month1 = z.Count(q => q.Month == 1),
                          Month2 = z.Count(q => q.Month == 2),
                          Month3 = z.Count(q => q.Month == 3),
                          Month4 = z.Count(q => q.Month == 4),
                          Month5 = z.Count(q => q.Month == 5),
                      }).ToList());
            var resultList = results.ToList();
        }
    }
